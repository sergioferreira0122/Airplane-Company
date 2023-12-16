using System.ComponentModel.DataAnnotations;

namespace webAPI.Presentation.Models.WriteModels
{
    public class DestinationWriteModel
    {
        [Required(ErrorMessage = "Name cannot be null.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "min lenght 3, max lenght 50")]
        public string Name { get; set; }

        [Range(0.0, 1_000_000)]
        public decimal Price { get; set; }
    }
}