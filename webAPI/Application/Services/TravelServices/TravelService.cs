using webAPI.Application.Mappers;
using webAPI.Application.Models.ViewModels;
using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;

namespace webAPI.Application.Services.TravelServices
{
    public class TravelService : ITravelCRUDServices
    {
        private readonly IRepository<Travel> _travelRepository;
        private readonly IRepository<Destination> _destinationRepository;

        public TravelService(IRepository<Travel> travelRepository,IRepository<Destination> destinationRepository)
        {
            _travelRepository = travelRepository;
            _destinationRepository = destinationRepository;
        }

        public Travel Add(Travel travel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Travel travel)
        {
            throw new NotImplementedException();
        }

        public Travel Edit(Travel travel, TravelWriteModel travelWriteModel)
        {
            throw new NotImplementedException();
        }

        public List<Travel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Travel? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
