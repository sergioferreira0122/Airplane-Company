using Airplane.Domain.Entities;
using Airplane.Domain.Interfaces.TravelInterfaces;

namespace webAPI.Application.Services.TravelServices
{
    public class TravelService : ITravelCrudServices, ITravelClientService
    {
        private readonly ITravelRepository _travelRepository;

        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public Travel Add(Travel travel, Destination destination)
        {
            travel.Destination = destination;

            _travelRepository.Add(travel);

            return travel;
        }

        public void Delete(Travel travel)
        {
            _travelRepository.Delete(travel);
        }

        public Travel Edit(Travel travel, Travel updateTravel, Destination destination)
        {
            EditFields(updateTravel, travel, destination);

            _travelRepository.Edit(travel);

            return travel;
        }

        private static Travel EditFields(Travel updateTravel, Travel travel, Destination destination)
        {
            travel.Destination = destination;
            travel.StartDate = updateTravel.StartDate;
            travel.EndDate = updateTravel.EndDate;

            return travel;
        }

        public List<Travel> GetAll()
        {
            return _travelRepository.GetAll().ToList();
        }

        public Travel? GetById(int id)
        {
            var travelFromRepository = _travelRepository.GetById(id);

            return travelFromRepository ?? null;
        }

        public ClientTravel AddClient(Travel travel, Client client)
        {
            var clientTravel = new ClientTravel
            {
                Travel = travel,
                Client = client,
                TravelId = travel.Id,
                ClientId = client.Id,
            };

            _travelRepository.AddClient(clientTravel);

            return clientTravel;
        }

        public ClientTravel RemoveClient(Travel travel, Client client)
        {
            var clientTravel = new ClientTravel
            {
                Travel = travel,
                Client = client,
                TravelId = travel.Id,
                ClientId = client.Id,
            };

            _travelRepository.RemoveClient(clientTravel);

            return clientTravel;
        }
    }
}