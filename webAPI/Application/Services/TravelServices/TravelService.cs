using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;

namespace webAPI.Application.Services.TravelServices
{
    public class TravelService : ITravelCRUDServices
    {
        private readonly IRepository<Travel> _travelRepository;

        public TravelService(IRepository<Travel> travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public Travel Add(Travel travel)
        {
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

            return travelFromRepository?? null;
        }
    }
}
