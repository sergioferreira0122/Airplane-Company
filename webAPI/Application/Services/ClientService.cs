    using System.Net;
using System.Web.Http;
using webAPI.Application.DTOs;
using webAPI.Application.Mappers;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories.Interfaces;

namespace webAPI.Application.Services
{
    public class ClientService : IClientCRUDService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientMapper _clientMapper;

        public ClientService(IClientRepository clientRepository, IClientMapper clientMapper)
        {
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
        }

        public void Add(ClientDTO clientDTO)
        {
            _clientRepository.Add(_clientMapper.MapClientDTOToClient(clientDTO));
        }

        public void Delete(int id)
        {
            Client clientFromRepo = GetClientNullable(id);

            _clientRepository.Delete(clientFromRepo);
        }

        public void Edit(int id, ClientDTO clientDTO)
        {
            Client clientFromRepo = GetClientNullable(id);

            EditFields(clientDTO, clientFromRepo);

            _clientRepository.Edit(clientFromRepo);
        }

        private Client EditFields(ClientDTO clientDTO, Client clientFromRepo)
        {
            clientFromRepo.Name = clientDTO.Name;

            return clientFromRepo;
        }

        public List<ClientDTO> GetAll()
        {
            return _clientMapper.
                MapClientListToClientDTOList(_clientRepository.getAll().ToList());
        }

        public ClientDTO GetById(int id)
        {
            return _clientMapper.
                MapClientToClientDTO(GetClientNullable(id));
        }

        private Client GetClientNullable(int id)   
        {
            Client? client = _clientRepository.GetById(id);

            if (client == null)
            {
                throw new InvalidOperationException();//TODO: ver melhor como atirar exceptions e a api retornar http codes
            }
            return client;
        }
    }
}
