using Airplane.API.Presentation.Controllers;
using Airplane.API.Presentation.Mappers;
using Airplane.API.Presentation.Models.ViewModels;
using Airplane.Application.Services.ClientServices;
using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Models;
using Airplane.Infrastructure;
using Airplane.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Airplane.Tests.Controllers
{
    public class ClientControllerTest
    {


        [Fact]
        public void GetById_ReturnsCorrectClient()
        {
            // Arrange
            var client = new ClientViewModel()
            {
                Id = 1,
                Name = "Teste",
            };

            var serviceMock = new Mock<IClientCrudService>();
            var logger = new Logger<ClientController>(new LoggerFactory());
            var clientMapper = new ClientMapper();

            var controller = new ClientController(logger, serviceMock.Object, clientMapper);

            serviceMock.Setup(s => s.GetById(1)).Returns(new Client()
            {
                Id = 1,
                Name = "Teste",
            });

            // Act
            var objectResult = controller.GetById(1) as ObjectResult;

            // Assert
            objectResult.Should().BeOfType<OkObjectResult>();
            objectResult.Value.Should().BeEquivalentTo(client);
            objectResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public void GetById_NotFoundClient()
        {
            // Arrange
            var serviceMock = new Mock<IClientCrudService>();
            var logger = new Logger<ClientController>(new LoggerFactory());
            var clientMapper = new ClientMapper();

            var controller = new ClientController(logger, serviceMock.Object, clientMapper);

            serviceMock.Setup(s => s.GetById(1)).Returns(new Client()
            {
                Id = 1,
                Name = "Teste",
            });

            // Act
            var objectResult = controller.GetById(2) as ObjectResult;

            // Assert
            objectResult.Should().BeOfType<NotFoundObjectResult>();
            objectResult.StatusCode.Should().Be(404);
        }
    }
}