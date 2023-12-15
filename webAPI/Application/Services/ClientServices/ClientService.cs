using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;
using webAPI.Infrastructure.Repositories.ClientRepository;

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

        public Client Edit(Client client, ClientWriteModel clientWriteModel)
        {
            EditFields(clientWriteModel, client);

            _clientRepository.Edit(client);

            return client;
        }

        private static Client EditFields(ClientWriteModel clientWriteModel, Client client)
        {
            client.Name = clientWriteModel.Name;

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