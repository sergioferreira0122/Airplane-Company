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

        public void Add(Destination entity)
        {
            _connectionContext.Destination.Add(entity);
            _connectionContext.SaveChanges();
        }

        public void Delete(Destination entity)
        {
            _connectionContext.Destination.Remove(entity);
            _connectionContext.SaveChanges();
        }

        public void Edit(Destination entity)
        {
            _connectionContext.Destination.Entry(entity).State = EntityState.Modified;
            _connectionContext.SaveChanges();
        }

        public IEnumerable<Destination> GetAll()
        {
            return _connectionContext.Destination.ToList();
        }

        public Destination? GetById(int id)
        {
            return _connectionContext.Destination.FirstOrDefault(x => x.Id == id);
        }
    }
}
