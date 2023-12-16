using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Interfaces.DestinationInterfaces;
using Airplane.Domain.Interfaces.TravelInterfaces;
using Microsoft.AspNetCore.Mvc;
using webAPI.Presentation.Mappers;
using webAPI.Presentation.Models.WriteModels;

namespace webAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TravelController : ControllerBase
{
    private readonly IClientCrudService _clientCrudService;
    private readonly ClientTravelMapper _clientTravelMapper;
    private readonly IDestinationCrudService _destinationCrudService;
    private readonly ILogger<TravelController> _logger;
    private readonly ITravelClientService _travelClientService;
    private readonly ITravelCrudServices _travelCrudServices;
    private readonly TravelMapper _travelMapper;

    public TravelController(ILogger<TravelController> logger,
        ITravelCrudServices travelCrudServices,
        IDestinationCrudService destinationCrudServices,
        TravelMapper travelMapper,
        ITravelClientService travelClientService,
        IClientCrudService clientCrudService,
        ClientTravelMapper clientTravelMapper)
    {
        _logger = logger;
        _travelCrudServices = travelCrudServices;
        _destinationCrudService = destinationCrudServices;
        _travelMapper = travelMapper;
        _travelClientService = travelClientService;
        _clientCrudService = clientCrudService;
        _clientTravelMapper = clientTravelMapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var travels = _travelCrudServices.GetAll();
        if (travels.Count == 0) return NoContent();

        _logger.LogInformation("GET ALL (Travel)");
        return Ok(_travelMapper.MapModelListToViewModelList(travels));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var travel = _travelCrudServices.GetById(id);
        if (travel == null) return NotFound("Travel not found.");

        _logger.LogInformation("GET (Travel): " + travel);
        return Ok(_travelMapper.MapModelToViewModel(travel));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var travel = _travelCrudServices.GetById(id);
        if (travel == null) return NotFound("Travel not found.");

        _travelCrudServices.Delete(travel);

        _logger.LogInformation("DELETE (Travel): " + travel);
        return Ok("Travel deleted.");
    }

    [HttpPost]
    public IActionResult Post(TravelWriteModel newTravelWriteModel)
    {
        var destination = _destinationCrudService.GetById(newTravelWriteModel.DestinationId);
        if (destination == null) return BadRequest("Destination not found.");

        var travel = _travelCrudServices.Add(_travelMapper.MapWriteModelToModel(newTravelWriteModel), destination);

        _logger.LogInformation("INSERT (Travel): " + travel);
        return Ok(_travelMapper.MapModelToViewModel(travel));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TravelWriteModel updatedTravelWriteModel)
    {
        var travel = _travelCrudServices.GetById(id);
        if (travel == null) return NotFound("Travel not found.");

        var destination = _destinationCrudService.GetById(updatedTravelWriteModel.DestinationId);
        if (destination == null) return BadRequest("Destination not found.");

        var travelUpdated = _travelCrudServices.Edit(travel,
            _travelMapper.MapWriteModelToModel(updatedTravelWriteModel), destination);

        _logger.LogInformation("UPDATE (Travel): " + travel);
        return Ok(_travelMapper.MapModelToViewModel(travelUpdated));
    }

    [HttpPut("add/client/{travelId}/{clientId}")]
    public IActionResult AddClientToTravel(int travelId, int clientId)
    {
        var travel = _travelCrudServices.GetById(travelId);
        if (travel == null) return NotFound("Travel not found.");

        var client = _clientCrudService.GetById(clientId);
        if (client == null) return NotFound("Client not found.");

        var clientTravelUpdated = _travelClientService.AddClient(travel, client);

        _logger.LogInformation("ADD CLIENT(ID:" + client.Id + ") TO TRAVEL(ID:" + travel.Id + ")");
        return Ok(_clientTravelMapper.MapClientTravelToClientTravelViewModel(clientTravelUpdated));
    }

    [HttpPut("remove/client/{travelId}/{clientId}")]
    public IActionResult RemoveClientToTravel(int travelId, int clientId)
    {
        var travel = _travelCrudServices.GetById(travelId);
        if (travel == null) return NotFound("Travel not found.");

        var client = _clientCrudService.GetById(clientId);
        if (client == null) return NotFound("Client not found.");

        var clientTravelUpdated = _travelClientService.RemoveClient(travel, client);

        _logger.LogInformation("REMOVE CLIENT(ID:" + client.Id + ") FROM TRAVEL(ID:" + travel.Id + ")");
        return Ok(_clientTravelMapper.MapClientTravelToClientTravelViewModel(clientTravelUpdated));
    }
}