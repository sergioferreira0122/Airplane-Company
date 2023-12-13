using webAPI.Application.DTOs;
using webAPI.Application.Mappers;
using webAPI.Controllers;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;

namespace webAPI.Application.Services.ClientServices
{
    public class ClientService : IClientCRUDService
    {
        private readonly ILogger<ClientService> _logger;
        private readonly IRepository<Client> _clientRepository;
        private readonly ClientMapper _clientMapper;

        public ClientService(ILogger<ClientService> logger, IRepository<Client> clientRepository, ClientMapper clientMapper)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
        }

        public Result<ClientDTO> Add(ClientDTO clientDTO)
        {
            Client client = _clientMapper.MapClientDTOToClient(clientDTO);

            bool responseFromRepository = _clientRepository.Add(client);

            _logger.LogInformation("INSERT (Client): " + client.ToString());
            return responseFromRepository ? new Result<ClientDTO>(200, clientDTO) : new Result<ClientDTO>(500);
        }

        public Result<ClientDTO> Delete(int id)
        {
            Result<Client> result = GetClientNullable(id);
            if (result.Data == null) { return new Result<ClientDTO>(404); }

            Client clientFromRepository = result.Data;
            ClientDTO clientDTO = _clientMapper.MapClientToClientDTO(clientFromRepository);

            bool responseFromRepository = _clientRepository.Delete(clientFromRepository);

            _logger.LogInformation("DELETE (Client): " + clientFromRepository.ToString());
            return responseFromRepository ? new Result<ClientDTO>(200, clientDTO) : new Result<ClientDTO>(500);
        }

        public Result<ClientDTO> Edit(int id, ClientDTO clientDTO)
        {
            Result<Client> result = GetClientNullable(id);
            if (result.Data == null) { return new Result<ClientDTO>(404); }

            Client clientFromRepository = result.Data;

            EditFields(clientDTO, clientFromRepository);
            ClientDTO newClientDTO = _clientMapper.MapClientToClientDTO(clientFromRepository);

            bool responseFromRepository = _clientRepository.Edit(clientFromRepository);

            _logger.LogInformation("UPDATE (Client): " + clientFromRepository.ToString());
            return responseFromRepository ? new Result<ClientDTO>(200, newClientDTO) : new Result<ClientDTO>(500);
        }

        private Client EditFields(ClientDTO clientDTO, Client clientFromRepo)
        {
            clientFromRepo.Name = clientDTO.Name;

            return clientFromRepo;
        }

        public Result<List<ClientDTO>> GetAll()
        {
            List<ClientDTO> listDTOs = _clientMapper.
                MapClientListToClientDTOList(_clientRepository.GetAll().ToList());

            _logger.LogInformation("GET ALL (Client)");
            return new Result<List<ClientDTO>>(200, listDTOs);
        }

        public Result<ClientDTO> GetById(int id)
        {
            Result<Client> result = GetClientNullable(id);
            if (result.Data == null) { return new Result<ClientDTO>(404); }

            Client clientFromRepository = result.Data;

            ClientDTO clientDTO = _clientMapper.MapClientToClientDTO(clientFromRepository);

            _logger.LogInformation("GET (Client): " + clientFromRepository.ToString());
            return new Result<ClientDTO>(200, clientDTO);
        }

        private Result<Client> GetClientNullable(int id)
        {
            Client? client = _clientRepository.GetById(id);

            return client != null ? new Result<Client>(200, client) : new Result<Client>(404);
        }
    }
}