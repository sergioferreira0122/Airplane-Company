using webAPI.Application.DTOs;
using webAPI.Domain.Models;

namespace webAPI.Application.Mappers
{
    public class DestinationMapper
    {
        public Destination MapDestinationDTOToDestination(DestinationDTO destinationDTO)
        {
            Destination destination = new Destination
            {
                Name = destinationDTO.Name,
                Price = destinationDTO.Price,
            };

            return destination;
        }

        public DestinationDTO MapDestinationToDestinationDTO(Destination destination)
        {
            DestinationDTO clientDTO = new DestinationDTO
            {
                Name = destination.Name,
                Price = destination.Price,
            };

            return clientDTO;
        }

        public List<DestinationDTO> MapDestinationListToDestinationDTOList(List<Destination> destinations)
        {
            List<DestinationDTO> list = new List<DestinationDTO>();

            foreach (Destination destination in destinations)
            {
                list.Add(MapDestinationToDestinationDTO(destination));
            }

            return list;
        }
    }
}
