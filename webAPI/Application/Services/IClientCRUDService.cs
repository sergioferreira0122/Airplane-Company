using MySqlX.XDevAPI.Common;
using webAPI.Application.DTOs;
using webAPI.Domain.Models;

namespace webAPI.Application.Services
{
    public interface IClientCRUDService
    {
        Result<List<ClientDTO>> GetAll();
        Result<ClientDTO> GetById(int id);
        Result<ClientDTO> Add(ClientDTO clientDTO);
        Result<ClientDTO> Edit(int id, ClientDTO clientDTO);
        Result<ClientDTO> Delete(int id);
    }
}