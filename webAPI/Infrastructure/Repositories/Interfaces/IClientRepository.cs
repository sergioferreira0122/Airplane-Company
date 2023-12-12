using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> getAll();
        Client? GetById(int id);
        void Add(Client client);
        void Edit(Client client);
        void Delete(Client client);
    }
}
