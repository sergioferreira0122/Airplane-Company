namespace webAPI.Presentation.Models.ViewModels
{
    public class TravelViewModel
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public required string DestinationName { get; set; }

        public required decimal DestinationPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
