using Microsoft.EntityFrameworkCore;
using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ClientRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void Add(Client entity)
        {
            _connectionContext.Clients.Add(entity);
            _connectionContext.SaveChanges();
        }

        public void Delete(Client entity)
        {
            _connectionContext.Clients.Remove(entity);
            _connectionContext.SaveChanges();
        }

        public void Edit(Client entity)
        {
            _connectionContext.Clients.Entry(entity).State = EntityState.Modified;
            _connectionContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _connectionContext.Clients
                .Include("ClientTravels")
                .Include("ClientDestinations")
                .ToList();
        }

        public Client? GetById(int id)
        {
            return _connectionContext.Clients
                .Include("ClientTravels")
                .Include("ClientDestinations")
                .FirstOrDefault(x => x.Id == id);
        }
    }
}