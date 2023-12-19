using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Presentation.Mappers;
using Airplane.Presentation.Models.WriteModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Airplane.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientCrudService _clientCrudService;
    private readonly ClientMapper _clientMapper;
    private readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger, IClientCrudService clientCrudService,
        ClientMapper clientMapper)
    {
        _logger = logger;
        _clientCrudService = clientCrudService;
        _clientMapper = clientMapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var clients = _clientCrudService.GetAll();
        if (clients.Count == 0) return NoContent();

        _logger.LogInformation("GET ALL (Client)");
        return Ok(_clientMapper.MapModelListToViewModelList(clients));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var client = _clientCrudService.GetById(id);
        if (client == null) return NotFound("Client not found.");

        _logger.LogInformation("GET (Client): " + client);
        return Ok(_clientMapper.MapModelToViewModel(client));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var client = _clientCrudService.GetById(id);
        if (client == null) return NotFound("Client not found.");

        _clientCrudService.Delete(client);

        _logger.LogInformation("DELETE (Client): " + client);
        return Ok("Client deleted.");
    }

    [HttpPost]
    public IActionResult Post(ClientWriteModel clientWriteModel)
    {
        var client = _clientCrudService.Add(_clientMapper.MapWriteModelToModel(clientWriteModel));

        _logger.LogInformation("INSERT (Client): " + client);
        return Ok(_clientMapper.MapModelToViewModel(client));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClientWriteModel updatedClientWriteModel)
    {
        var client = _clientCrudService.GetById(id);
        if (client == null) return NotFound("Client not found.");

        var clientUpdated =
            _clientCrudService.Edit(client, _clientMapper.MapWriteModelToModel(updatedClientWriteModel));

        _logger.LogInformation("UPDATE (Client): " + clientUpdated);
        return Ok(_clientMapper.MapModelToViewModel(clientUpdated));
    }
}