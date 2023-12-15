using webAPI.Domain.Models;

namespace webAPI.Application.Services.TravelServices
{
    public interface ITravelClientService
    {
        Travel AddClient(Travel travel, Client client);
        Travel RemoveClient(Travel travel, Client client);
    }
}
