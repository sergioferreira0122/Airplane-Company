using Microsoft.AspNetCore.Mvc;
using webAPI.Domain.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelController : ControllerBase
    {
        public TravelController()
        {

        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpPost()]
        public IActionResult Post(Travel newTravel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Travel updatedTravel)
        {
            return Ok();
        }
    }
}