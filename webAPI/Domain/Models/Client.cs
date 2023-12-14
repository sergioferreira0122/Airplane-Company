using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Domain.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<Travel>? Travels { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}}}";
        }
    }
}