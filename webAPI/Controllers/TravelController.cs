using Microsoft.AspNetCore.Mvc;
using webAPI.Domain.Models;

namespace webAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class TravelController : ControllerBase
    {

        private static List<Travel> travelList = new List<Travel>();
        private static List<Destination> destinationList = new List<Destination>();
        private static List<Client> clientList = new List<Client>();

        private readonly ILogger<TravelController> _logger;

        public TravelController(ILogger<TravelController> logger)
        {
            _logger = logger;

            destinationList.Add(new Destination
            {
                Id = 1,
                Name = "Paris",
                Price = 200.00
            });

            clientList.Add(new Client
            {
                Id = 1,
                Name = "Sérgio"
            });

            clientList.Add(new Client
            {
                Id = 2,
                Name = "Tiago"
            });

            clientList.Add(new Client
            {
                Id = 3,
                Name = "Daniel"
            });

            if (travelList.Count == 0)
            {

                travelList.Add(new Travel
                {
                    Id = 1,
                    Destination = destinationList.ElementAt(0),
                    Client = clientList,
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(15)
                }); // dado para exemplo

                travelList.Add(new Travel
                {
                    Id = 2,
                    Destination = destinationList.ElementAt(0),
                    Client = clientList,
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(15)
                }); // dado para exemplo

                travelList.Add(new Travel
                {
                    Id = 3,
                    Destination = destinationList.ElementAt(0),
                    Client = clientList,
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(15)
                }); // dado para exemplo
            }
        }

        /// <summary>
        /// Gets the list of all Travels.
        /// </summary>
        /// <returns>The list of Travels.</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(travelList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Travel? travel = travelList.Find(travel => travel.Id == id);

            if (travel == null) { return NotFound(); }

            return Ok(travel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Travel? travel = travelList.Find(travel => travel.Id == id);

            if (travel == null) { return NotFound(); }

            travelList.Remove(travel);

            return Ok();
        }

        [HttpPost()]
        public IActionResult Post(Travel newTravel)
        {
            travelList.Add(newTravel);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Travel updatedTravel)
        {
            Travel? existingTravel = travelList.Find(travel => travel.Id == id);

            if (existingTravel == null)
            {
                return NotFound();
            }

            existingTravel.Destination = updatedTravel.Destination;
            existingTravel.Client = updatedTravel.Client;
            existingTravel.StartDate = updatedTravel.StartDate;
            existingTravel.EndDate = updatedTravel.EndDate;

            return Ok(existingTravel);
        }
    }
}