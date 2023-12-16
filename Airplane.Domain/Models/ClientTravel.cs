namespace Airplane.Domain.Entities
{
    public class ClientTravel
    {
        public int TravelId { get; set; }
        public required Travel Travel { get; set; }

        public int ClientId { get; set; }
        public required Client Client { get; set; }
    }
}