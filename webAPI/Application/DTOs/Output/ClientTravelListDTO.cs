namespace webAPI.Application.DTOs.Output
{
    public class ClientTravelListDTO
    {
        public required string ClientName { get; set; }

        public List<TravelDTO>? Travels { get; set; }
    }
}
