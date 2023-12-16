using Airplane.Domain.Entities;
using webAPI.Presentation.Models.ViewModels;
using webAPI.Presentation.Models.WriteModels;

namespace webAPI.Presentation.Mappers;

public class TravelMapper
{
    public Travel MapWriteModelToModel(TravelWriteModel travelWriteModel)
    {
        var travel = new Travel
        {
            StartDate = travelWriteModel.StartDate,
            EndDate = travelWriteModel.EndDate
        };

        return travel;
    }

    public TravelViewModel MapModelToViewModel(Travel travel)
    {
        var travelViewModel = new TravelViewModel
        {
            Id = travel.Id,
            DestinationId = travel.Destination!.Id,
            DestinationName = travel.Destination!.Name,
            DestinationPrice = travel.Destination!.Price,
            StartDate = travel.StartDate,
            EndDate = travel.EndDate
        };

        return travelViewModel;
    }

    public List<TravelViewModel> MapModelListToViewModelList(List<Travel> travels)
    {
        var list = new List<TravelViewModel>();

        foreach (var travel in travels) list.Add(MapModelToViewModel(travel));

        return list;
    }
}