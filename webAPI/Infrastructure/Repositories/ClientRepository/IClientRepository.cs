using webAPI.Domain.Models;

namespace webAPI.Infrastructure.Repositories.ClientRepository
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();

        Client? GetById(int id);

        void Add(Client entity);

        void Edit(Client entity);

        void Delete(Client entity);
    }
}
