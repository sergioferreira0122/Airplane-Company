using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories.DestinationRepository
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
