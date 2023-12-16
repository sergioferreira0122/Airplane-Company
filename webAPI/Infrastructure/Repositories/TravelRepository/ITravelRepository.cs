using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories.TravelRepository
{
    public interface ITravelRepository
    {
        IEnumerable<Travel> GetAll();

        Travel? GetById(int id);

        void Add(Travel entity);

        void Edit(Travel entity);

        void Delete(Travel entity);

        void AddClient (ClientTravel clientTravel);
        void RemoveClient(ClientTravel clientTravel);
    }
}
