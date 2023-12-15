using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;
using webAPI.Infrastructure.Repositories.TravelRepository;

namespace webAPI.Application.Services.TravelServices
{
    public class TravelService : ITravelCRUDServices, ITravelClientService
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

        public Travel Edit(Travel travel, TravelWriteModel travelWriteModel, Destination destination)
        {
            EditFields(travelWriteModel, travel, destination);

            _travelRepository.Edit(travel);

            return travel;
        }

        private static Travel EditFields(TravelWriteModel travelWriteModel, Travel travel, Destination destination)
        {
            travel.Destination = destination;
            travel.StartDate = travelWriteModel.StartDate;
            travel.EndDate = travelWriteModel.EndDate;

            return travel;
        }

        public List<Travel> GetAll()
        {
            return _travelRepository.GetAll().ToList();
        }

        public Travel? GetById(int id)
        {
            Travel? travelFromRepository = _travelRepository.GetById(id);

            return travelFromRepository ?? null;
        }

        public Travel AddClient(Travel travel, Client client)
        {
            travel.AddClient(client);

            _travelRepository.AddClient(travel, client);

            return travel;
        }

        public Travel RemoveClient(Travel travel, Client client)
        {
            travel.RemoveClient(client);

            _travelRepository.RemoveClient(travel, client);

            return travel;
        }
    }
}
