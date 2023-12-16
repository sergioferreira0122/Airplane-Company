using System.ComponentModel.DataAnnotations;

namespace webAPI.Domain.Models
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