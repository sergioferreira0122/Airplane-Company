using Microsoft.AspNetCore.Mvc;
using System.Net;
using webAPI.Application.DTOs;
using webAPI.Application.Services;
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
            return Ok(_clientCRUDService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_clientCRUDService.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientCRUDService.Delete(id);
            return Ok();
        }


        [HttpPost()]
        public IActionResult Post(ClientDTO newClientDTO)
        {
            _clientCRUDService.Add(newClientDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientDTO updatedClientDTO)
        {
            _clientCRUDService.Edit(id, updatedClientDTO);
            return Ok();
        }

    }
}
