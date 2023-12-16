using System.ComponentModel.DataAnnotations;

namespace Airplane.Domain.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<ClientTravel>? ClientTravels { get; set; }
        public ICollection<ClientDestination>? ClientDestinations { get; set; }
    }
}