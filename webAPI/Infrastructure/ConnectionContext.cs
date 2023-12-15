using Microsoft.EntityFrameworkCore;
using webAPI.Domain.Models;

namespace webAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Client> Clients { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        public ConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("Database")!);
        }

    }
}