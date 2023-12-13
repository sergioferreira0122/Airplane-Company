using webAPI.Application.DTOs;
using webAPI.Domain.Models;

namespace webAPI.Application.Mappers
{
    public class ClientMapper : IClientMapper
    {
        public Client MapClientDTOToClient(ClientDTO clientDTO)
        {
            Client client = new Client
            {
                Name = clientDTO.Name
            };

            return client;
        }

        public ClientDTO MapClientToClientDTO(Client client)
        {
            ClientDTO clientDTO = new ClientDTO
            {
                Name = client.Name
            };

            return clientDTO;
        }

        public List<ClientDTO> MapClientListToClientDTOList(List<Client> clients)
        {
            List<ClientDTO> list = new List<ClientDTO>();

            foreach (Client client in clients)
            {
                list.Add(MapClientToClientDTO(client));
            }

            return list;
        }
    }
}