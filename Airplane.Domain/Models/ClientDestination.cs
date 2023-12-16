namespace Airplane.Domain.Entities
{
    public class ClientDestination
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}