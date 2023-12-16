using Airplane.Domain.Models;

namespace Airplane.Domain.Interfaces.TravelInterfaces
{
    public interface ITravelCrudServices
    {
        List<Travel> GetAll();

        Travel? GetById(int id);

        Travel Add(Travel travel, Destination destination);

        Travel Edit(Travel travel, Travel updateTravel, Destination destination);

        void Delete(Travel travel);
    }
}