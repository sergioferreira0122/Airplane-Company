using Microsoft.AspNetCore.Mvc;
using webAPI.Domain.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase
    {

        private static List<Destination> destinationList = new List<Destination>();

        private readonly ILogger<DestinationController> _logger;

        public DestinationController(ILogger<DestinationController> logger)
        {
            _logger = logger;

            if (destinationList.Count == 0)
            {
                destinationList.Add(new Destination
                {
                    Id = 1,
                    Name = "Paris",
                    Price = 200.00
                });

                destinationList.Add(new Destination
                {
                    Id = 2,
                    Name = "Luxemburgo",
                    Price = 250.00
                }); 

            }
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(destinationList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           Destination? destination = destinationList.Find(destination => destination.Id == id);

           if (destination == null) { return NotFound(); }

           return Ok(destination);
        }

        [HttpPost()]
        public IActionResult Post(Destination newDestination)
        {
           destinationList.Add(newDestination);
           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Destination? destination = destinationList.Find(destination => destination.Id == id);

            if (destination == null) { return NotFound(); }

            destinationList.Remove(destination);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Destination updatedDestination)
        {
            Destination? existingDestination = destinationList.Find(destination => destination.Id == id);

            if (existingDestination == null)
            {
                return NotFound();
            }

            existingDestination.Name = updatedDestination.Name;
            existingDestination.Price = updatedDestination.Price;

            return Ok(existingDestination);
        }
    }
}
