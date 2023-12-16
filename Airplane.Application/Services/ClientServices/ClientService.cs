using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Models;

namespace Airplane.Application.Services.ClientServices
{
    public class ClientService : IClientCrudService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Add(Client client)
        {
            _clientRepository.Add(client);

            return client;
        }

        public void Delete(Client client)
        {
            _clientRepository.Delete(client);
        }

        public Client Edit(Client client, Client updateClient)
        {
            EditFields(updateClient, client);

            _clientRepository.Edit(client);

            return client;
        }

        private static void EditFields(Client updateClient, Client client)
        {
            client.Name = updateClient.Name;
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll().ToList();
        }

        public Client? GetById(int id)
        {
            var clientFromRepository = _clientRepository.GetById(id);

            return clientFromRepository ?? null;
        }
    }
}