using Microsoft.AspNetCore.Mvc;
using webAPI.Application.DTOs;
using webAPI.Application.Services.ClientServices;
using webAPI.Domain.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientCRUDService _clientCRUDService;

        public ClientController(IClientCRUDService clientCRUDService)
        {
            _clientCRUDService = clientCRUDService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            Result<List<ClientDTO>> result = _clientCRUDService.GetAll();
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Result<ClientDTO> result = _clientCRUDService.GetById(id);
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result<ClientDTO> result = _clientCRUDService.Delete(id);
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpPost()]
        public IActionResult Post(ClientDTO newClientDTO)
        {
            Result<ClientDTO> result = _clientCRUDService.Add(newClientDTO);
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientDTO updatedClientDTO)
        {
            Result<ClientDTO> result = _clientCRUDService.Edit(id, updatedClientDTO);
            return StatusCode(result.HttpCode, result.Data);
        }
    }
}