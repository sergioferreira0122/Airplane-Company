using webAPI.Domain.Models;
using webAPI.Presentation.Models.WriteModels;

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
