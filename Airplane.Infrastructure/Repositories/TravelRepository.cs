using Airplane.Domain.Interfaces.TravelInterfaces;
using Airplane.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Airplane.Infrastructure.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ConnectionContext _connectionContext;

        public TravelRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void Add(Travel entity)
        {
            _connectionContext.Travels.Add(entity);

            _connectionContext.Destinations.Attach(entity.Destination!);

            _connectionContext.SaveChanges();
        }

        public void Delete(Travel entity)
        {
            _connectionContext.Travels.Remove(entity);
            _connectionContext.SaveChanges();
        }

        public void Edit(Travel entity)
        {
            _connectionContext.Travels.Entry(entity).State = EntityState.Modified;
            _connectionContext.SaveChanges();
        }

        public IEnumerable<Travel> GetAll()
        {
            return _connectionContext.Travels
                .Include("Destination")
                .Include("ClientTravels")
                .ToList();
        }

        public Travel? GetById(int id)
        {
            return _connectionContext.Travels
                .Include("Destination")
                .Include("ClientTravels")
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddClient(ClientTravel clientTravel)
        {
            _connectionContext.Clients.Attach(clientTravel.Client);
            _connectionContext.Travels.Attach(clientTravel.Travel);

            _connectionContext.ClientTravels.Add(clientTravel);

            _connectionContext.SaveChanges();
        }

        public void RemoveClient(ClientTravel clientTravel)
        {
            _connectionContext.ClientTravels.Entry(clientTravel).State = EntityState.Deleted;

            _connectionContext.SaveChanges();
        }
    }
}