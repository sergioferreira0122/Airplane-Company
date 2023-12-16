using Airplane.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Airplane.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Client> Clients { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<ClientDestination> ClientDestinations { get; set; }
        public DbSet<ClientTravel> ClientTravels { get; set; }

        public ConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("Database")!);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientDestination>()
                    .HasKey(cd => new { cd.ClientId, cd.DestinationId });
            modelBuilder.Entity<ClientDestination>()
                    .HasOne(c => c.Client)
                    .WithMany(cd => cd.ClientDestinations)
                    .HasForeignKey(c => c.ClientId);
            modelBuilder.Entity<ClientDestination>()
                    .HasOne(d => d.Destination)
                    .WithMany(cd => cd.ClientDestinations)
                    .HasForeignKey(d => d.DestinationId);

            modelBuilder.Entity<ClientTravel>()
                    .HasKey(ct => new { ct.ClientId, ct.TravelId });
            modelBuilder.Entity<ClientTravel>()
                    .HasOne(c => c.Client)
                    .WithMany(ct => ct.ClientTravels)
                    .HasForeignKey(c => c.ClientId);
            modelBuilder.Entity<ClientTravel>()
                    .HasOne(t => t.Travel)
                    .WithMany(ct => ct.ClientTravels)
                    .HasForeignKey(t => t.TravelId);
        }
    }
}