namespace webAPI.Application.Models.ViewModels
{
    public class TravelClientsViewModel
    {
        public int TravelId { get; set; }
        public List<ClientViewModel>? Clients { get; set; }
    }
}
