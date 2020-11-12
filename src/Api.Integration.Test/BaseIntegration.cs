using Application;
using AutoMapper;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext {get; private set;}
        public HttpClient client {get;private set;}
        public IMapper mapper {get;set;}
        public string hostApi {get;set;}
        public HttpResponseMessage response {get;set;}

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api/";
            var builder  = new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseStartup<Startup>();

            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();

            client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto
            {
                    Email = "adm@adm.com"
            };
            
            var resultLogin  = await PostJsonAsync(loginDto, $"{hostApi}Login", client);
            var JsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(JsonLogin);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.acessToken);
        }
        public static async Task<HttpResponseMessage> PostJsonAsync ( object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataclass), System.Text.Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFixture: IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg=>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });
            return config.CreateMapper();
        }
        public void Dispose ()
        {

        }
    }
}