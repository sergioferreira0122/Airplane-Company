using Airplane.Domain.Entities;

namespace Airplane.Domain.Interfaces.ClientInterfaces
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