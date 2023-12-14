using Microsoft.EntityFrameworkCore;
using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly ConnectionContext _connectionContext;

        public ClientRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void Add(Client entity)
        {
            _connectionContext.Client.Add(entity);
            _connectionContext.SaveChanges();
        }

        public void Delete(Client entity)
        {
            _connectionContext.Client.Remove(entity);
            _connectionContext.SaveChanges();
        }

        public void Edit(Client entity)
        {
            _connectionContext.Client.Entry(entity).State = EntityState.Modified;
            _connectionContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _connectionContext.Client
                .Include("Travels")
                .ToList();
        }

        public Client? GetById(int id)
        {
            return _connectionContext.Client
                .Include("Travels")
                .FirstOrDefault(x => x.Id == id);
        }
    }
}