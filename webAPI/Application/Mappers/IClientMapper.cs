using webAPI.Application.DTOs;
using webAPI.Domain.Models;

namespace webAPI.Application.Mappers
{
    public interface IClientMapper
    {
        Client MapClientDTOToClient(ClientDTO clientDTO);
        ClientDTO MapClientToClientDTO(Client client);
        List<ClientDTO> MapClientListToClientDTOList(List<Client> clients);
    }
}
