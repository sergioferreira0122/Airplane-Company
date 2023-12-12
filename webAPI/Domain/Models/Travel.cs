using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Domain.Models
{
    [Table("Travel")]
    public class Travel
    {
        [Key] public int Id { get; set; }
        [Required] public Destination Destination { get; set; }
        public List<Client> Client { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
    }
}