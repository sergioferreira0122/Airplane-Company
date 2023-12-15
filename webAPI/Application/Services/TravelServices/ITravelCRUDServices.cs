using webAPI.Application.Models.ViewModels;
using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;

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
