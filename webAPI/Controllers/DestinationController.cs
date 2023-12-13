using Microsoft.AspNetCore.Mvc;
using webAPI.Application.DTOs;
using webAPI.Application.Services.DestinationServices;
using webAPI.Application.Utils;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationCRUDService _destinationCRUDService;

        public DestinationController(IDestinationCRUDService destinationCRUDService)
        {
            _destinationCRUDService = destinationCRUDService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            Result<List<DestinationDTO>> result = _destinationCRUDService.GetAll();
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Result<DestinationDTO> result = _destinationCRUDService.GetById(id);
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpPost()]
        public IActionResult Post(DestinationDTO newDestinationDTO)
        {
            Result<DestinationDTO> result = _destinationCRUDService.Add(newDestinationDTO);
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Result<DestinationDTO> result = _destinationCRUDService.Delete(id);
            return StatusCode(result.HttpCode, result.Data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DestinationDTO updatedDestinationDTO)
        {
            Result<DestinationDTO> result = _destinationCRUDService.Edit(id, updatedDestinationDTO);
            return StatusCode(result.HttpCode, result.Data);
        }
    }
}