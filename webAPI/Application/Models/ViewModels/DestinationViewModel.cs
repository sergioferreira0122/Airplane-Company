namespace webAPI.Application.Models.ViewModels
{
    public class DestinationViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }
    }
}
