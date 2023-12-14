using webAPI.Application.Models.ViewModels;
using webAPI.Application.Models.WriteModels;
using webAPI.Domain.Models;

namespace webAPI.Application.Mappers
{
    public class ClientMapper
    {
        public Client MapWriteModelToModel(ClientWriteModel clientWriteModel)
        {
            Client client = new Client
            {
                Name = clientWriteModel.Name,
            };

            return client;
        }

        public ClientViewModel MapModelToViewModel(Client client)
        {
            ClientViewModel clientViewModel = new ClientViewModel
            {
                Id = client.Id,
                Name = client.Name,
            };

            return clientViewModel;
        }

        public List<ClientViewModel> MapModelListToViewModelList(List<Client> clients)
        {
            List<ClientViewModel> list = new List<ClientViewModel>();

            foreach (Client client in clients)
            {
                list.Add(MapModelToViewModel(client));
            }

            return list;
        }
    }
}