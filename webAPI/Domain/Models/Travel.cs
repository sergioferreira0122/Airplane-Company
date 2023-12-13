using System;
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

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }
    }
}