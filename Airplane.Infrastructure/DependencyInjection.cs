using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Interfaces.DestinationInterfaces;
using Airplane.Domain.Interfaces.TravelInterfaces;
using Airplane.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Airplane.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Connection
            services.AddTransient<ConnectionContext>();
            //Connection

            //Repositories
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IDestinationRepository, DestinationRepository>();
            services.AddTransient<ITravelRepository, TravelRepository>();
            //Repositories

            return services;
        }
    }
}
