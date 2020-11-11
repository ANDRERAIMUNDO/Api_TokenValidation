using Api.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest ()
        {

        }
    }
    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"DbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider  ServiceProvider{get; private set;}
        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext> (o =>
            o.UseMySql($"Server=localhost;Port=3306;Database={dataBaseName};Uid=root;Pwd=123456"),
            ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}