using webAPI.Domain.Models;
using webAPI.Presentation.Models.ViewModels;

namespace webAPI.Presentation.Mappers
{
    public class ClientTravelMapper
    {
        private readonly TravelMapper _travelMapper;

        public ClientTravelMapper(TravelMapper travelMapper)
        {
            _travelMapper = travelMapper;
        }

        public ClientTravelViewModel MapClientTravelToClientTravelViewModel(ClientTravel clientTravel)
        {
            ClientTravelViewModel clientTravelViewModel = new ClientTravelViewModel
            {
                ClientId = clientTravel.Client.Id,
                ClientName = clientTravel.Client.Name,
                Travel = _travelMapper.MapModelToViewModel(clientTravel.Travel),
            };

            return clientTravelViewModel;
        }
    }
}
