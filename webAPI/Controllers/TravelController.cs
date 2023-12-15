using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Mappers;
using webAPI.Application.Models.WriteModels;
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
        private readonly TravelMapper _travelMapper;

        public TravelController(ILogger<TravelController> logger, ITravelCRUDServices travelCRUDServices, IDestinationCRUDService destinationCRUDServices, TravelMapper travelMapper)
        {
            _logger = logger;
            _travelCRUDServices = travelCRUDServices;
            _destinationCRUDService = destinationCRUDServices;
            _travelMapper = travelMapper;
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
    }
}