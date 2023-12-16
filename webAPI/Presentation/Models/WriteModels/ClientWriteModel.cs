using System.ComponentModel.DataAnnotations;

namespace Airplane.API.Presentation.Models.WriteModels
{
    public class ClientWriteModel
    {
        [Required(ErrorMessage = "Name cannot be null.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "min lenght 3, max lenght 50")]
        public string Name { get; set; }
    }
}