using Airplane.Domain.Models;

namespace Airplane.Domain.Interfaces.TravelInterfaces
{
    public interface ITravelRepository
    {
        IEnumerable<Travel> GetAll();

        Travel? GetById(int id);

        void Add(Travel entity);

        void Edit(Travel entity);

        void Delete(Travel entity);

        void AddClient(ClientTravel clientTravel);

        void RemoveClient(ClientTravel clientTravel);
    }
}