using Api.Service.Services;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.Extensions.DependencyInjection;
namespace Api.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices (IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<ICepService, CepService>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
        }
    }
}       