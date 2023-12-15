using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories.TravelRepository
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
                .Include("Clients")
                .ToList();
        }

        public Travel? GetById(int id)
        {
            return _connectionContext.Travels
                .Include("Destination")
                .Include("Clients")
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddClient(Travel entity, Client client)
        {
            _connectionContext.Clients.Entry(client).State = EntityState.Modified;

            _connectionContext.Travels.Entry(entity).State = EntityState.Modified;

            _connectionContext.SaveChanges();
        }

        public void RemoveClient(Travel entity, Client client)
        {
            _connectionContext.Clients.Attach(client).State = EntityState.Modified;

            _connectionContext.Travels.Entry(entity).State = EntityState.Modified;

            _connectionContext.SaveChanges();
        }
    }
}
