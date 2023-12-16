using webAPI.Domain.Models;

namespace webAPI.Application.Services.TravelServices
{
    public interface ITravelClientService
    {
        ClientTravel AddClient(Travel travel, Client client);
        ClientTravel RemoveClient(Travel travel, Client client);
    }
}
