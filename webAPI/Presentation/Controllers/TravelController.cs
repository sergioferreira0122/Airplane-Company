using Airplane.Domain.Entities;
using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Interfaces.DestinationInterfaces;
using Airplane.Domain.Interfaces.TravelInterfaces;
using Microsoft.AspNetCore.Mvc;
using webAPI.Presentation.Mappers;
using webAPI.Presentation.Models.WriteModels;

namespace webAPI.Presentation.Controllers
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
        private readonly ClientTravelMapper _clientTravelMapper;

        public TravelController(ILogger<TravelController> logger,
            ITravelCRUDServices travelCRUDServices,
            IDestinationCRUDService destinationCRUDServices,
            TravelMapper travelMapper,
            ITravelClientService travelClientService,
            IClientCRUDService clientCRUDService,
            ClientTravelMapper clientTravelMapper)
        {
            _logger = logger;
            _travelCRUDServices = travelCRUDServices;
            _destinationCRUDService = destinationCRUDServices;
            _travelMapper = travelMapper;
            _travelClientService = travelClientService;
            _clientCRUDService = clientCRUDService;
            _clientTravelMapper = clientTravelMapper;
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
            Destination? destination = _destinationCRUDService.GetById(newTravelWriteModel.DestinationId);
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

            Travel travelUpdated = _travelCRUDServices.Edit(travel, _travelMapper.MapWriteModelToModel(updatedTravelWriteModel), destination);

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

            ClientTravel clientTravelUpdated = _travelClientService.AddClient(travel, client);

            _logger.LogInformation("ADD CLIENT(ID:" + client.Id + ") TO TRAVEL(ID:" + travel.Id + ")");
            return Ok(_clientTravelMapper.MapClientTravelToClientTravelViewModel(clientTravelUpdated));
        }

        [HttpPut("remove/client/{travelId}/{clientId}")]
        public IActionResult RemoveClientToTravel(int travelId, int clientId)
        {
            Travel? travel = _travelCRUDServices.GetById(travelId);
            if (travel == null) { return NotFound("Travel not found."); }

            Client? client = _clientCRUDService.GetById(clientId);
            if (client == null) { return NotFound("Client not found."); }

            ClientTravel clientTravelUpdated = _travelClientService.RemoveClient(travel, client);

            _logger.LogInformation("REMOVE CLIENT(ID:" + client.Id + ") FROM TRAVEL(ID:" + travel.Id + ")");
            return Ok(_clientTravelMapper.MapClientTravelToClientTravelViewModel(clientTravelUpdated));
        }
    }
}