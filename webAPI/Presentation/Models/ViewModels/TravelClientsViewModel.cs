namespace Airplane.API.Presentation.Models.ViewModels
{
    public class TravelClientsViewModel
    {
        public int TravelId { get; set; }
        public ICollection<ClientViewModel>? Clients { get; set; }
    }
}