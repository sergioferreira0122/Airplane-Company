namespace webAPI.Application.DTOs.Output
{
    public class ClientTravelListDTO
    {
        public required string Name { get; set; }

        public List<TravelDTO>? Travels { get; set; }
    }
}
