using Airplane.Domain.Entities;
using Airplane.Domain.Interfaces.DestinationInterfaces;
using Microsoft.AspNetCore.Mvc;
using webAPI.Presentation.Mappers;
using webAPI.Presentation.Models.WriteModels;

namespace webAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly ILogger<DestinationController> _logger;
        private readonly IDestinationCRUDService _destinationCRUDService;
        private readonly DestinationMapper _destinationMapper;

        public DestinationController(ILogger<DestinationController> logger, IDestinationCRUDService destinationCRUDService, DestinationMapper destinationMapper)
        {
            _logger = logger;
            _destinationCRUDService = destinationCRUDService;
            _destinationMapper = destinationMapper;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            List<Destination> destinations = _destinationCRUDService.GetAll();
            if (destinations.Count == 0) { return NoContent(); }

            _logger.LogInformation("GET ALL (Destination)");
            return Ok(_destinationMapper.MapModelListToViewModelList(destinations));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Destination? destination = _destinationCRUDService.GetById(id);
            if (destination == null) { return NotFound("Destination not found."); }

            _logger.LogInformation("GET (Destination): " + destination.ToString());
            return Ok(_destinationMapper.MapModelToViewModel(destination));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Destination? destination = _destinationCRUDService.GetById(id);
            if (destination == null) { return NotFound("Destination not found."); }

            _destinationCRUDService.Delete(destination);

            _logger.LogInformation("GET (Destination): " + destination.ToString());
            return Ok("Destination deleted.");
        }

        [HttpPost()]
        public IActionResult Post(DestinationWriteModel destinationWriteModel)
        {
            Destination destination = _destinationCRUDService.Add(_destinationMapper.MapWriteModelToModel(destinationWriteModel));

            _logger.LogInformation("GET (Destination): " + destination.ToString());
            return Ok(_destinationMapper.MapModelToViewModel(destination));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DestinationWriteModel updatedDestinationWriteModel)
        {
            Destination? destination = _destinationCRUDService.GetById(id);
            if (destination == null) { return NotFound("Destination not found."); }

            Destination destinationUpdated = _destinationCRUDService.Edit(destination, _destinationMapper.MapWriteModelToModel(updatedDestinationWriteModel));

            _logger.LogInformation("UPDATE (Destination): " + destinationUpdated.ToString());
            return Ok(_destinationMapper.MapModelToViewModel(destination));
        }
    }
}