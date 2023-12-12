using webAPI.Application.DTOs;

namespace webAPI.Application.Services
{
    public interface IClientCRUDService
    {
        List<ClientDTO> GetAll();
        ClientDTO GetById(int id);
        void Add(ClientDTO clientDTO);
        void Edit(int id, ClientDTO clientDTO);
        void Delete(int id);
    }
}
