using System.ComponentModel.DataAnnotations;

namespace Airplane.Domain.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<ClientDestination>? ClientDestinations { get; set; }

        public ICollection<Travel>? Travels { get; set; }
    }
}