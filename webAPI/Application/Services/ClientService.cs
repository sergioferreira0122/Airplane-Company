using System.Net;
using System.Web.Http;
using webAPI.Application.DTOs;
using webAPI.Application.Mappers;
using webAPI.Controllers;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;

namespace webAPI.Application.Services
{
    public class ClientService : IClientCRUDService
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IRepository<Client> _clientRepository;
        private readonly IClientMapper _clientMapper;

        public ClientService(ILogger<ClientController> logger , IRepository<Client> clientRepository, IClientMapper clientMapper)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
        }

        public void Add(ClientDTO clientDTO)
        {
            Client client = _clientMapper.MapClientDTOToClient(clientDTO);

            _logger.LogInformation("INSERT: " + client.ToString());

            _clientRepository.Add(client);
        }

        public void Delete(int id)
        {
            Client clientFromRepo = GetClientNullable(id);

            _logger.LogInformation("DELETE: " + clientFromRepo.ToString());

            _clientRepository.Delete(clientFromRepo);
        }

        public void Edit(int id, ClientDTO clientDTO)
        {
            Client clientFromRepo = GetClientNullable(id);

            EditFields(clientDTO, clientFromRepo);

            _logger.LogInformation("UPDATE: " + clientFromRepo.ToString());

            _clientRepository.Edit(clientFromRepo);
        }

        private Client EditFields(ClientDTO clientDTO, Client clientFromRepo)
        {
            clientFromRepo.Name = clientDTO.Name;

            return clientFromRepo;
        }

        public List<ClientDTO> GetAll()
        {
            _logger.LogInformation("GET ALL");

            return _clientMapper.
                MapClientListToClientDTOList(_clientRepository.FindAll().ToList());
        }

        public ClientDTO GetById(int id)
        {
            Client clientFromRepo = GetClientNullable(id);

            _logger.LogInformation("GET: " + clientFromRepo.ToString());

            return _clientMapper.MapClientToClientDTO(clientFromRepo);
        }

        private Client GetClientNullable(int id)   
        {
            Client? client = _clientRepository.FindById(id) ?? throw new HttpResponseException(HttpStatusCode.NotFound);
            //TODO: Ver como atirar exçecões com http codes

            return client;
        }
    }
}
