using Airplane.Domain.Models;

namespace Airplane.Domain.Interfaces.ClientInterfaces
{
    public interface IClientCrudService
    {
        List<Client> GetAll();

        Client? GetById(int id);

        Client Add(Client client);

        Client Edit(Client client, Client updateClient);

        void Delete(Client client);
    }
}