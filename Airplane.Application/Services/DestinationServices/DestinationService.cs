using Airplane.Domain.Entities;
using Airplane.Domain.Interfaces.DestinationInterfaces;

namespace webAPI.Application.Services.DestinationServices
{
    public class DestinationService : IDestinationCrudService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IDestinationRepository destinationRepository)
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

        public Destination Edit(Destination destination, Destination updateDestination)
        {
            EditFields(updateDestination, destination);

            _destinationRepository.Edit(destination);

            return destination;
        }

        private static Destination EditFields(Destination updateDestination, Destination destination)
        {
            destination.Price = updateDestination.Price;
            destination.Name = updateDestination.Name;

            return destination;
        }

        public List<Destination> GetAll()
        {
            return _destinationRepository.GetAll().ToList();
        }

        public Destination? GetById(int id)
        {
            var destinationFromRepository = _destinationRepository.GetById(id);

            return destinationFromRepository ?? null;
        }
    }
}