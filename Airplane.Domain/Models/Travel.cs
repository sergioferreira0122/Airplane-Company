using System.ComponentModel.DataAnnotations;

namespace Airplane.Domain.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }

        public Destination? Destination { get; set; }

        public ICollection<ClientTravel>? ClientTravels { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}