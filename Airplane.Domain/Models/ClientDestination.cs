namespace Airplane.Domain.Models
{
    public class ClientDestination
    {
        public int ClientId { get; set; }
        public required Client Client { get; set; }

        public int DestinationId { get; set; }
        public required Destination Destination { get; set; }
    }
}