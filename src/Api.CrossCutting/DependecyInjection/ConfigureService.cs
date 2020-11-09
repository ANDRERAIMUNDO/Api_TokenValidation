using Api.Service.Services;
using Api.Domain.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;
namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices (IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}   