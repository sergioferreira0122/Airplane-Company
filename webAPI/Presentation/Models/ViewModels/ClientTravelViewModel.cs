namespace webAPI.Presentation.Models.ViewModels
{
    public class ClientTravelViewModel
    {
        public int ClientId { get; set; }
        public required string ClientName { get; set; }
        public required TravelViewModel Travel { get; set; }
    }
}
