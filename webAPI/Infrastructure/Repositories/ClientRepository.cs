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

        public bool Add(Client entity)
        {
            _connectionContext.Client.Add(entity);
            return _connectionContext.SaveChanges() > 0;
        }

        public bool Delete(Client entity)
        {
            _connectionContext.Client.Remove(entity);
            return _connectionContext.SaveChanges() > 0;
        }

        public bool Edit(Client entity)
        {
            _connectionContext.Client.Entry(entity).State = EntityState.Modified;
            return _connectionContext.SaveChanges() > 0;
        }

        public IEnumerable<Client> GetAll()
        {
            return _connectionContext.Client.ToList();
        }

        public Client? GetById(int id)
        {
            return _connectionContext.Client.Find(id);
        }
    }
}