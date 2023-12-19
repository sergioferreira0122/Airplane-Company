using Airplane.Application.Services.ClientServices;
using Airplane.Application.Services.DestinationServices;
using Airplane.Application.Services.TravelServices;
using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Interfaces.DestinationInterfaces;
using Airplane.Domain.Interfaces.TravelInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Airplane.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Services
            services.AddTransient<IClientCrudService, ClientService>();
            services.AddTransient<IDestinationCrudService, DestinationService>();
            services.AddTransient<ITravelCrudServices, TravelService>();
            services.AddTransient<ITravelClientService, TravelService>();
            //Services

            return services;
        }
    }
}
