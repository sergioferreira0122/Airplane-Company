using webAPI.Application.Models.ViewModels;
using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;

namespace webAPI.Application.Mappers
{
    public class TravelMapper
    {
        private readonly ClientMapper _clientMapper;

        public TravelMapper(ClientMapper clientMapper)
        {
            _clientMapper = clientMapper;
        }

        public Travel MapWriteModelToModel(TravelWriteModel travelWriteModel)
        {
            Travel travel = new Travel
            {
                StartDate = travelWriteModel.StartDate,
                EndDate = travelWriteModel.EndDate,
            };

            return travel;
        }

        public TravelViewModel MapModelToViewModel(Travel travel)
        {
            TravelViewModel travelViewModel = new TravelViewModel
            {
                Id = travel.Id,
                DestinationId = travel.Destination!.Id,
                DestinationName = travel.Destination!.Name,
                DestinationPrice = travel.Destination!.Price,
                StartDate = travel.StartDate,
                EndDate = travel.EndDate,
            };

            return travelViewModel;
        }

        public List<TravelViewModel> MapModelListToViewModelList(List<Travel> travels)
        {
            List<TravelViewModel> list = new List<TravelViewModel>();

            foreach (Travel travel in travels)
            {
                list.Add(MapModelToViewModel(travel));
            }

            return list;
        }

        public TravelClientsViewModel MapModelToTravelClientViewModel(Travel travel)
        {
            TravelClientsViewModel tr = new TravelClientsViewModel
            {
                TravelId = travel.Id,
                Clients = _clientMapper.MapModelListToViewModelList(travel.Clients!),
            };

            return tr;
        }
    }
}
