using webAPI.Domain.Models;
using webAPI.Presentation.Models.WriteModels;

namespace webAPI.Application.Services.TravelServices
{
    public interface ITravelCRUDServices
    {
        List<Travel> GetAll();

        Travel? GetById(int id);

        Travel Add(Travel travel, Destination destination);

        Travel Edit(Travel travel, TravelWriteModel travelWriteModel, Destination destination);

        void Delete(Travel travel);
    }
}
