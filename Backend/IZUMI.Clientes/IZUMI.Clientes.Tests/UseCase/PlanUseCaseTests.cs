using AutoMapper;
using FluentAssertions;
using IZUMI.Clientes.Application.DTO;
using IZUMI.Clientes.Application.UseCase;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace IZUMI.Clientes.Tests.UseCase
{
    public class PlanUseCaseTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPlanService> _planServiceMock;
        private readonly Mock<ILogger<PlanUseCase>> _loggerMock;
        private readonly PlanUseCase _planUseCase;

        public PlanUseCaseTests()
        {
            _mapperMock = new Mock<IMapper>();
            _planServiceMock = new Mock<IPlanService>();
            _loggerMock = new Mock<ILogger<PlanUseCase>>();
            _planUseCase = new PlanUseCase(_mapperMock.Object, _planServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task ObtenerListaPlanes_DebeRetornarListaExitosamente()
        {
            // Arrange
            var planes = new List<PlanEntity> 
            { 
                new PlanEntity { Id = 1, Nombre = "Plan Basico" },
                new PlanEntity { Id = 2, Nombre = "Plan Premium" }
            };
            var planesDTO = new List<PlanDTO> 
            { 
                new PlanDTO { Id = 1, Nombre = "Plan Basico" },
                new PlanDTO { Id = 2, Nombre = "Plan Premium" }
            };
            
            _planServiceMock.Setup(x => x.ObtenerListaPlanes()).ReturnsAsync(planes);
            _mapperMock.Setup(x => x.Map<List<PlanDTO>>(planes)).Returns(planesDTO);

            // Act
            var resultado = await _planUseCase.ObtenerListaPlanes();

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().NotBeNull();
            resultado.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task ObtenerListaPlanes_CuandoHayError_DebeRetornarErrorResponse()
        {
            // Arrange
            _planServiceMock.Setup(x => x.ObtenerListaPlanes()).ThrowsAsync(new Exception("Error de BD"));

            // Act
            var resultado = await _planUseCase.ObtenerListaPlanes();

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }
    }
}
