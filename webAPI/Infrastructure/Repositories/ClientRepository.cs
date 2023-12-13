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

        public IEnumerable<Client> FindAll()
        {
            return _connectionContext.Client.ToList();
        }

        public Client? FindById(int id)
        {
            return _connectionContext.Client.Find(id);
        }

        public bool Add(Client client)
        {
            _connectionContext.Client.Add(client);
            return _connectionContext.SaveChanges() > 0;
        }

        public bool Delete(Client client)
        {
            _connectionContext.Remove(client);
            return _connectionContext.SaveChanges() > 0;
        }

        public bool Edit(Client client)
        {
            _connectionContext.Client.Entry(client).State = EntityState.Modified;
            return _connectionContext.SaveChanges() > 0;
        }
    }
}
