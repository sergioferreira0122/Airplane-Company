using Airplane.API.Presentation.Models.ViewModels;
using Airplane.API.Presentation.Models.WriteModels;
using Airplane.Domain.Models;

namespace Airplane.API.Presentation.Mappers;

public class DestinationMapper
{
    public Destination MapWriteModelToModel(DestinationWriteModel destinationWriteModel)
    {
        var destination = new Destination
        {
            Name = destinationWriteModel.Name,
            Price = destinationWriteModel.Price
        };

        return destination;
    }

    public DestinationViewModel MapModelToViewModel(Destination destination)
    {
        var destinationViewModel = new DestinationViewModel
        {
            Id = destination.Id,
            Name = destination.Name,
            Price = destination.Price
        };

        return destinationViewModel;
    }

    public List<DestinationViewModel> MapModelListToViewModelList(List<Destination> destinations)
    {
        var list = new List<DestinationViewModel>();

        foreach (var destination in destinations) list.Add(MapModelToViewModel(destination));

        return list;
    }
}