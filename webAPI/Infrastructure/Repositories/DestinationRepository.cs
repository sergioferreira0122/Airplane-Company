using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories
{
    public class DestinationRepository : IRepository<Destination>
    {
        private readonly ConnectionContext _connectionContext;

        public DestinationRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public bool Add(Destination entity)
        {
            _connectionContext.Destination.Add(entity);
            return _connectionContext.SaveChanges() > 0;
        }

        public bool Delete(Destination entity)
        {
            _connectionContext.Destination.Remove(entity);
            return _connectionContext.SaveChanges() > 0;
        }

        public bool Edit(Destination entity)
        {
            _connectionContext.Destination.Entry(entity).State = EntityState.Modified;
            return _connectionContext.SaveChanges() > 0;
        }

        public IEnumerable<Destination> GetAll()
        {
            return _connectionContext.Destination.ToList();
        }

        public Destination? GetById(int id)
        {
            return _connectionContext.Destination.Find(id);
        }
    }
}
