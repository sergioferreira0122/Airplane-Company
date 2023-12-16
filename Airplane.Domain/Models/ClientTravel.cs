namespace Airplane.Domain.Entities
{
    public class ClientTravel
    {
        public int TravelId { get; set; }
        public Travel Travel { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}