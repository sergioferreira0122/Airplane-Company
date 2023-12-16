using Airplane.Domain.Entities;

namespace Airplane.Domain.Interfaces.DestinationInterfaces
{
    public interface IDestinationRepository
    {
        IEnumerable<Destination> GetAll();

        Destination? GetById(int id);

        void Add(Destination entity);

        void Edit(Destination entity);

        void Delete(Destination entity);
    }
}