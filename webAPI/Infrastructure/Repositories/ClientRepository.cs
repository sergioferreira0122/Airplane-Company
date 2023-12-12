using Microsoft.EntityFrameworkCore;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories.Interfaces;

namespace webAPI.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ClientRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public IEnumerable<Client> getAll()
        {
            return _connectionContext.Client.ToList();
        }

        public Client? GetById(int id)
        {
            return _connectionContext.Client.Find(id);
        }

        public void Add(Client client)
        {
            _connectionContext.Client.Add(client);
            _connectionContext.SaveChanges();
        }

        public void Delete(Client client)
        {
            _connectionContext.Remove(client);
            _connectionContext.SaveChanges();
        }

        public void Edit(Client client)
        {
            _connectionContext.Client.Entry(client).State = EntityState.Modified;
            _connectionContext.SaveChanges();
        }
    }
}
