using webAPI.Application.Models.ViewModels;
using webAPI.Domain.Models;
using webAPI.Presentation.Models.WriteModels;

namespace webAPI.Application.Services.ClientServices
{
    public interface IClientCRUDService
    {
        List<Client> GetAll();

        Client? GetById(int id);

        Client Add(Client client);

        Client Edit(Client client, ClientWriteModel clientWriteModel);

        void Delete(Client client);
    }
}