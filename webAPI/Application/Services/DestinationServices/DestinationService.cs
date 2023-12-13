using webAPI.Application.DTOs;
using webAPI.Application.Mappers;
using webAPI.Controllers;
using webAPI.Domain.Models;
using webAPI.Infrastructure.Repositories;

namespace webAPI.Application.Services.DestinationServices
{
    public class DestinationService : IDestinationCRUDService
    {
        private readonly ILogger<DestinationService> _logger;
        private readonly IRepository<Destination> _destinationRepository;
        private readonly DestinationMapper _destinationMapper;

        public DestinationService(ILogger<DestinationService> logger, IRepository<Destination> destinationRepository, DestinationMapper destinationMapper)
        {
            _logger = logger;
            _destinationRepository = destinationRepository;
            _destinationMapper = destinationMapper;
        }

        public Result<DestinationDTO> Add(DestinationDTO destinationDTO)
        {
            Destination destination = _destinationMapper.MapDestinationDTOToDestination(destinationDTO);

            bool responseFromRepository = _destinationRepository.Add(destination);

            _logger.LogInformation("INSERT (Destination): " + destination.ToString());
            return responseFromRepository ? new Result<DestinationDTO>(200, destinationDTO) : new Result<DestinationDTO>(500);
        }

        public Result<DestinationDTO> Delete(int id)
        {
            Result<Destination> result = GetDestinationNullable(id);
            if (result.Data == null) { return new Result<DestinationDTO>(404); }

            Destination destinationFromRepository = result.Data;
            DestinationDTO destinationDTO = _destinationMapper.MapDestinationToDestinationDTO(destinationFromRepository);

            bool responseFromRepository = _destinationRepository.Delete(destinationFromRepository);

            _logger.LogInformation("DELETE (Destination): " + destinationFromRepository.ToString());
            return responseFromRepository ? new Result<DestinationDTO>(200, destinationDTO) : new Result<DestinationDTO>(500);
        }

        public Result<DestinationDTO> Edit(int id, DestinationDTO destinationDTO)
        {
            Result<Destination> result = GetDestinationNullable(id);
            if (result.Data == null) { return new Result<DestinationDTO>(404); }

            Destination destinationFromRepository = result.Data;

            EditFields(destinationDTO, destinationFromRepository);
            DestinationDTO newDestinationDTO = _destinationMapper.MapDestinationToDestinationDTO(destinationFromRepository);

            bool responseFromRepository = _destinationRepository.Edit(destinationFromRepository);

            _logger.LogInformation("UPDATE (Destination): " + destinationFromRepository.ToString());
            return responseFromRepository ? new Result<DestinationDTO>(200, newDestinationDTO) : new Result<DestinationDTO>(500);
        }

        private Destination EditFields(DestinationDTO destinationDTO, Destination destinationFromRepo)
        {
            destinationFromRepo.Name = destinationDTO.Name;
            destinationFromRepo.Price = destinationDTO.Price;

            return destinationFromRepo;
        }

        public Result<List<DestinationDTO>> GetAll()
        {
            List<DestinationDTO> listDTOs = _destinationMapper.
                MapDestinationListToDestinationDTOList(_destinationRepository.GetAll().ToList());

            _logger.LogInformation("GET ALL (Destination)");
            return new Result<List<DestinationDTO>>(200, listDTOs);
        }

        public Result<DestinationDTO> GetById(int id)
        {
            Result<Destination> result = GetDestinationNullable(id);
            if (result.Data == null) { return new Result<DestinationDTO>(404); }

            Destination destinationFromRepository = result.Data;

            DestinationDTO destinationDTO = _destinationMapper.MapDestinationToDestinationDTO(destinationFromRepository);

            _logger.LogInformation("GET (Client): " + destinationFromRepository.ToString());
            return new Result<DestinationDTO>(200, destinationDTO);
        }

        private Result<Destination> GetDestinationNullable(int id)
        {
            Destination? destination = _destinationRepository.GetById(id);

            return destination != null ? new Result<Destination>(200, destination) : new Result<Destination>(404);
        }
    }
}
