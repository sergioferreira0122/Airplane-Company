using Airplane.Domain.Entities;
using Airplane.Domain.Interfaces.ClientInterfaces;

namespace webAPI.Application.Services.ClientServices
{
    public class ClientService : IClientCRUDService
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

        private static Client EditFields(Client updateClient, Client client)
        {
            client.Name = updateClient.Name;

            return client;
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll().ToList();
        }

        public Client? GetById(int id)
        {
            Client? clientFromRepository = _clientRepository.GetById(id);

            return clientFromRepository ?? null;
        }
    }
}