using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementations>();
            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(options =>
            options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(options =>
            options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }
        }
    }
}