using Airplane.Domain.Entities;

namespace Airplane.Domain.Interfaces.DestinationInterfaces
{
    public interface IDestinationCRUDService
    {
        List<Destination> GetAll();

        Destination? GetById(int id);

        Destination Add(Destination destination);

        Destination Edit(Destination destination, Destination updateDestination);

        void Delete(Destination destination);
    }
}