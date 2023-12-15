using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Mappers;
using webAPI.Application.Models.WriteModels;
using webAPI.Application.Services.ClientServices;
using webAPI.Application.Services.DestinationServices;
using webAPI.Application.Services.TravelServices;
using webAPI.Domain.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelController : ControllerBase
    {
        private readonly ILogger<TravelController> _logger;
        private readonly ITravelCRUDServices _travelCRUDServices;
        private readonly IDestinationCRUDService _destinationCRUDService;
        private readonly ITravelClientService _travelClientService;
        private readonly IClientCRUDService _clientCRUDService;
        private readonly TravelMapper _travelMapper;

        public TravelController(ILogger<TravelController> logger,
            ITravelCRUDServices travelCRUDServices,
            IDestinationCRUDService destinationCRUDServices,
            TravelMapper travelMapper,
            ITravelClientService travelClientService,
            IClientCRUDService clientCRUDService)
        {
            _logger = logger;
            _travelCRUDServices = travelCRUDServices;
            _destinationCRUDService = destinationCRUDServices;
            _travelMapper = travelMapper;
            _travelClientService = travelClientService;
            _clientCRUDService = clientCRUDService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            List<Travel> travels = _travelCRUDServices.GetAll();
            if (travels.Count == 0) { return NoContent(); }

            _logger.LogInformation("GET ALL (Travel)");
            return Ok(_travelMapper.MapModelListToViewModelList(travels));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Travel? travel = _travelCRUDServices.GetById(id);
            if (travel == null) { return NotFound("Travel not found."); }

            _logger.LogInformation("GET (Travel): " + travel.ToString());
            return Ok(_travelMapper.MapModelToViewModel(travel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Travel? travel = _travelCRUDServices.GetById(id);
            if (travel == null) { return NotFound("Travel not found."); }

            _travelCRUDServices.Delete(travel);

            _logger.LogInformation("DELETE (Travel): " + travel.ToString());
            return Ok("Travel deleted.");
        }

        [HttpPost()]
        public IActionResult Post(TravelWriteModel newTravelWriteModel)
        {
            Destination? destination= _destinationCRUDService.GetById(newTravelWriteModel.DestinationId);
            if (destination == null) { return BadRequest("Destination not found."); }

            Travel travel = _travelCRUDServices.Add(_travelMapper.MapWriteModelToModel(newTravelWriteModel), destination);

            _logger.LogInformation("INSERT (Travel): " + travel.ToString());
            return Ok(_travelMapper.MapModelToViewModel(travel));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TravelWriteModel updatedTravelWriteModel)
        {
            Travel? travel = _travelCRUDServices.GetById(id);
            if (travel == null) { return NotFound("Travel not found."); }

            Destination? destination = _destinationCRUDService.GetById(updatedTravelWriteModel.DestinationId);
            if (destination == null) { return BadRequest("Destination not found."); }

            Travel travelUpdated = _travelCRUDServices.Edit(travel, updatedTravelWriteModel, destination);

            _logger.LogInformation("UPDATE (Travel): " + travel.ToString());
            return Ok(_travelMapper.MapModelToViewModel(travelUpdated));
        }

        [HttpPut("add/client/{travelId}/{clientId}")]
        public IActionResult AddClientToTravel(int travelId, int clientId)
        {
            Travel? travel = _travelCRUDServices.GetById(travelId);
            if (travel == null) { return NotFound("Travel not found."); }

            Client? client = _clientCRUDService.GetById(clientId);
            if (client == null) { return NotFound("Client not found."); }

            Travel travelUpdated = _travelClientService.AddClient(travel, client);

            _logger.LogInformation("ADD CLIENT(ID:" + client.Id + ") TO TRAVEL(ID:" + travel.Id + ")");
            return Ok(_travelMapper.MapModelToTravelClientViewModel(travelUpdated));
        }

        [HttpPut("remove/client/{travelId}/{clientId}")]
        public IActionResult RemoveClientToTravel(int travelId, int clientId)
        {
            Travel? travel = _travelCRUDServices.GetById(travelId);
            if (travel == null) { return NotFound("Travel not found."); }

            Client? client = _clientCRUDService.GetById(clientId);
            if (client == null) { return NotFound("Client not found."); }

            Travel travelUpdated = _travelClientService.RemoveClient(travel, client);

            _logger.LogInformation("REMOVE CLIENT(ID:" + client.Id + ") FROM TRAVEL(ID:" + travel.Id + ")");
            return Ok(_travelMapper.MapModelToTravelClientViewModel(travelUpdated));
        }
    }
}