using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Interfaces.DestinationInterfaces;
using Airplane.Domain.Interfaces.TravelInterfaces;
using Airplane.Infrastructure.Repositories;
using Airplane.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Airplane.Presentation.Mappers;

namespace Airplane.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            //Mappers
            services.AddTransient<ClientMapper>();
            services.AddTransient<DestinationMapper>();
            services.AddTransient<TravelMapper>();
            services.AddTransient<ClientTravelMapper>();
            //Mappers

            return services;
        }
    }
}
