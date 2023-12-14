using webAPI.Application.Models.ViewModels;
using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;

namespace webAPI.Application.Services.DestinationServices
{
    public interface IDestinationCRUDService
    {
        List<Destination> GetAll();

        Destination? GetById(int id);

        Destination Add(Destination destination);

        Destination Edit(Destination destination, DestinationWriteModel destinationWriteModel);

        void Delete(Destination destination);
    }
}
