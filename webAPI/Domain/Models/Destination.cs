using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Domain.Models
{
    [Table("Destination")]
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }
    }
}