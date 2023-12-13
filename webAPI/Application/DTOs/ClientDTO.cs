using System.ComponentModel.DataAnnotations;

namespace webAPI.Application.DTOs
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 50 caracteres.")]
        public string Name { get; set; }
    }
}
