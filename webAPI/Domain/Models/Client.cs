using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Domain.Models
{
    [Table("Client")]
    public class Client
    {
        [Key] public int Id { get; set; }
        [Required(AllowEmptyStrings = false)] public string Name { get; set; }//TODO: Ver porque allow empty strins nao funciona
    }
}