using Airplane.Domain.Interfaces.DestinationInterfaces;
using Airplane.Presentation.Mappers;
using Airplane.Presentation.Models.WriteModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Airplane.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DestinationController : ControllerBase
{
    private readonly IDestinationCrudService _destinationCrudService;
    private readonly DestinationMapper _destinationMapper;
    private readonly ILogger<DestinationController> _logger;

    public DestinationController(ILogger<DestinationController> logger, IDestinationCrudService destinationCrudService,
        DestinationMapper destinationMapper)
    {
        _logger = logger;
        _destinationCrudService = destinationCrudService;
        _destinationMapper = destinationMapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var destinations = _destinationCrudService.GetAll();
        if (destinations.Count == 0) return NoContent();

        _logger.LogInformation("GET ALL (Destination)");
        return Ok(_destinationMapper.MapModelListToViewModelList(destinations));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var destination = _destinationCrudService.GetById(id);
        if (destination == null) return NotFound("Destination not found.");

        _logger.LogInformation("GET (Destination): " + destination);
        return Ok(_destinationMapper.MapModelToViewModel(destination));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var destination = _destinationCrudService.GetById(id);
        if (destination == null) return NotFound("Destination not found.");

        _destinationCrudService.Delete(destination);

        _logger.LogInformation("GET (Destination): " + destination);
        return Ok("Destination deleted.");
    }

    [HttpPost]
    public IActionResult Post(DestinationWriteModel destinationWriteModel)
    {
        var destination = _destinationCrudService.Add(_destinationMapper.MapWriteModelToModel(destinationWriteModel));

        _logger.LogInformation("GET (Destination): " + destination);
        return Ok(_destinationMapper.MapModelToViewModel(destination));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DestinationWriteModel updatedDestinationWriteModel)
    {
        var destination = _destinationCrudService.GetById(id);
        if (destination == null) return NotFound("Destination not found.");

        var destinationUpdated = _destinationCrudService.Edit(destination,
            _destinationMapper.MapWriteModelToModel(updatedDestinationWriteModel));

        _logger.LogInformation("UPDATE (Destination): " + destinationUpdated);
        return Ok(_destinationMapper.MapModelToViewModel(destination));
    }
}