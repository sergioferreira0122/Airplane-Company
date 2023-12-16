using Airplane.Domain.Entities;

namespace Airplane.Domain.Interfaces.TravelInterfaces
{
    public interface ITravelCRUDServices
    {
        List<Travel> GetAll();

        Travel? GetById(int id);

        Travel Add(Travel travel, Destination destination);

        Travel Edit(Travel travel, Travel updateTravel, Destination destination);

        void Delete(Travel travel);
    }
}