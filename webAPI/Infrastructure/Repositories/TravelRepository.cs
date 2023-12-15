using Microsoft.EntityFrameworkCore;
using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories
{
    public class TravelRepository : IRepository<Travel>
    {
        private readonly ConnectionContext _connectionContext;

        public TravelRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void Add(Travel entity)
        {
            _connectionContext.Travel.Add(entity);
            
            _connectionContext.Destination.Attach(entity.Destination);

            _connectionContext.SaveChanges();
        }

        public void Delete(Travel entity)
        {
            _connectionContext.Travel.Remove(entity);
            _connectionContext.SaveChanges();
        }

        public void Edit(Travel entity)
        {
            _connectionContext.Travel.Entry(entity).State = EntityState.Modified;
            _connectionContext.SaveChanges();
        }

        public IEnumerable<Travel> GetAll()
        {
            return _connectionContext.Travel
                .Include("Destination")
                .ToList();
        }

        public Travel? GetById(int id)
        {
            return _connectionContext.Travel
                .Include("Destination")
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
