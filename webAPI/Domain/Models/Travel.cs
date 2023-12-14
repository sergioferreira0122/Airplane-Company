using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Domain.Models
{
    [Table("Travel")]
    public class Travel
    {
        [Key]
        public int Id { get; set; }

        public required Destination Destination { get; set; }

        public List<Client>? Client { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Destination)}={Destination}, {nameof(StartDate)}={StartDate.ToString()}, {nameof(EndDate)}={EndDate.ToString()}}}";
        }
    }
}