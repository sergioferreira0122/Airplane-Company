using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories.DestinationRepository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ConnectionContext _connectionContext;

        public DestinationRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void Add(Destination entity)
        {
            _connectionContext.Destinations.Add(entity);
            _connectionContext.SaveChanges();
        }

        public void Delete(Destination entity)
        {
            _connectionContext.Destinations.Remove(entity);
            _connectionContext.SaveChanges();
        }

        public void Edit(Destination entity)
        {
            _connectionContext.Destinations.Entry(entity).State = EntityState.Modified;
            _connectionContext.SaveChanges();
        }

        public IEnumerable<Destination> GetAll()
        {
            return _connectionContext.Destinations.ToList();
        }

        public Destination? GetById(int id)
        {
            return _connectionContext.Destinations.FirstOrDefault(x => x.Id == id);
        }
    }
}
