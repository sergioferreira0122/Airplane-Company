using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;

namespace webAPI.Application.Services.DestinationServices
{
    public class DestinationService : IDestinationCRUDService
    {
        private readonly IRepository<Destination> _destinationRepository;

        public DestinationService(IRepository<Destination> destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public Destination Add(Destination destination)
        {
            _destinationRepository.Add(destination);

            return destination;
        }

        public void Delete(Destination destination)
        {
            _destinationRepository.Delete(destination);
        }

        public Destination Edit(Destination destination, DestinationWriteModel destinationWriteModel)
        {
            EditFields(destinationWriteModel, destination);

            _destinationRepository.Edit(destination);

            return destination;
        }

        private static Destination EditFields(DestinationWriteModel destinationWriteModel, Destination destination)
        {
            destination.Price = destinationWriteModel.Price;
            destination.Name = destinationWriteModel.Name;

            return destination;
        }

        public List<Destination> GetAll()
        {
            return _destinationRepository.GetAll().ToList();
        }

        public Destination? GetById(int id)
        {
            Destination? destinationFromRepository = _destinationRepository.GetById(id);

            return destinationFromRepository ?? null;
        }
    }
}
