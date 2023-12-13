using webAPI.Application.DTOs;
using webAPI.Domain.Models;

namespace webAPI.Application.Services.DestinationServices
{
    public interface IDestinationCRUDService
    {
        Result<List<DestinationDTO>> GetAll();

        Result<DestinationDTO> GetById(int id);

        Result<DestinationDTO> Add(DestinationDTO destinationDTO);

        Result<DestinationDTO> Edit(int id, DestinationDTO destinationDTO);

        Result<DestinationDTO> Delete(int id);
    }
}
