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
