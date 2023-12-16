using Airplane.Domain.Models;

namespace Airplane.Domain.Interfaces.TravelInterfaces
{
    public interface ITravelClientService
    {
        ClientTravel AddClient(Travel travel, Client client);

        ClientTravel RemoveClient(Travel travel, Client client);
    }
}