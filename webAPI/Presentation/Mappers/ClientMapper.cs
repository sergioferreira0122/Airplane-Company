using Airplane.Domain.Entities;
using webAPI.Presentation.Models.ViewModels;
using webAPI.Presentation.Models.WriteModels;

namespace webAPI.Presentation.Mappers;

public class ClientMapper
{
    public Client MapWriteModelToModel(ClientWriteModel clientWriteModel)
    {
        var client = new Client
        {
            Name = clientWriteModel.Name
        };

        return client;
    }

    public ClientViewModel MapModelToViewModel(Client client)
    {
        var clientViewModel = new ClientViewModel
        {
            Id = client.Id,
            Name = client.Name
        };

        return clientViewModel;
    }

    public List<ClientViewModel> MapModelListToViewModelList(List<Client> clients)
    {
        var list = new List<ClientViewModel>();

        foreach (var client in clients) list.Add(MapModelToViewModel(client));

        return list;
    }
}