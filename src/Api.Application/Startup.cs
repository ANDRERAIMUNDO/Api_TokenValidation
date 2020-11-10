using System.Reflection.PortableExecutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Api.CrossCutting.Mappings;
using Api.CrossCutting.DependecyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Api.Domain.Security;
using Api.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureService.ConfigureDependenciesServices(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            }
            );
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var signigConfigurations = new SigningConfigurations();
            services.AddSingleton(signigConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);    
                
                services.AddAuthentication(authOptions =>
                {
                   authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(bearerOptions =>
                {
                    var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signigConfigurations.key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
                });
                
                services.AddAuthorization(auth =>
                {
                    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
                });
          // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
          // services.AddControllers();
           services.AddSwaggerGen(c =>
           {    
               c.SwaggerDoc ("v1", new OpenApiInfo
               {
                Version = "v1",
                Title = "API ASP NetCore 3.1",
                Description = "Arquitera DDD",
                TermsOfService = new Uri("http" + "://www.linkedin.com/in/andreraimundoo/"), 
                Contact = new OpenApiContact
               {
                    Name = "Andre Raimundo",
                    Email = "9000andre@gmail.com",
                    Url = new Uri ("http://www.linkedin.com/in/andreraimundoo/")
               },
                License = new OpenApiLicense
               {
                    Name = "Termos de uso",
                    Url = new Uri ("http://www.linkedin.com/in/andreraimundoo/")
               }
            });
           c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
           {
               Description = "Enter token JWT",
               Name = "Authorization",
               In = ParameterLocation.Header,
               Type = SecuritySchemeType.ApiKey
           });
           c.AddSecurityRequirement (new OpenApiSecurityRequirement
           {
               {
               new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                       Id = "Bearer",
                       Type = ReferenceType.SecurityScheme
                   }
               }, new List<string>()
            }
           });
        });
    }  
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ASP NetCore 3.1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if(Environment.GetEnvironmentVariable("MIGRATION").ToLower()=="APLICAR".ToLower())
            {
                using (var service  = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
                {
                    using(var context = service.ServiceProvider.GetService<MyContext>())
                    {
                        context.Database.Migrate();
                    }
                }
                
            }
        }
    }
}
