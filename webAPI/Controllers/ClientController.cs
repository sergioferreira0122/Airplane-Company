using Microsoft.AspNetCore.Mvc;
using webAPI.Application.Mappers;
using webAPI.Application.Models.ViewModels;
using webAPI.Application.Models.WriteModels;
using webAPI.Application.Services.ClientServices;
using webAPI.Domain.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientCRUDService _clientCRUDService;
        private readonly ClientMapper _clientMapper;

        public ClientController(ILogger<ClientController> logger ,IClientCRUDService clientCRUDService, ClientMapper clientMapper)
        {
            _logger = logger;
            _clientCRUDService = clientCRUDService;
            _clientMapper = clientMapper;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            List<Client> clients = _clientCRUDService.GetAll();
            if (clients.Count == 0) { return NoContent(); }

            _logger.LogInformation("GET ALL (Client)");
            return Ok(_clientMapper.MapModelListToViewModelList(clients));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Client? client = _clientCRUDService.GetById(id);
            if (client == null) { return NotFound("Client not found."); }

            _logger.LogInformation("GET (Client): " + client.ToString());
            return Ok(_clientMapper.MapModelToViewModel(client));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Client? client = _clientCRUDService.GetById(id);
            if (client == null) { return NotFound("Client not found."); }

            _clientCRUDService.Delete(client);

            _logger.LogInformation("DELETE (Client): " + client.ToString());
            return Ok("Client deleted.");
        }

        [HttpPost()]
        public IActionResult Post(ClientWriteModel clientWriteModel)
        {
            Client client = _clientCRUDService.Add(_clientMapper.MapWriteModelToModel(clientWriteModel));

            _logger.LogInformation("INSERT (Client): " + client.ToString());
            return Ok(_clientMapper.MapModelToViewModel(client));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientWriteModel updatedClientWriteModel)
        {
            Client? client = _clientCRUDService.GetById(id);
            if (client == null) { return NotFound("Client not found."); }

            Client clientUpdated = _clientCRUDService.Edit(client, updatedClientWriteModel);

            _logger.LogInformation("UPDATE (Client): " + clientUpdated.ToString());
            return Ok(_clientMapper.MapModelToViewModel(clientUpdated));
        }
    }
}