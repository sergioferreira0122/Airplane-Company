namespace Airplane.API.Presentation.Models.ViewModels
{
    public class ClientTravelViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public TravelViewModel Travel { get; set; }
    }
}