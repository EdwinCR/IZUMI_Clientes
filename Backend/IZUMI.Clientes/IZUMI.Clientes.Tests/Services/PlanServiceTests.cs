using FluentAssertions;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Domain.Services;
using Moq;

namespace IZUMI.Clientes.Tests.Services
{
    public class PlanServiceTests
    {
        private readonly Mock<IPlanRepository> _repositoryMock;
        private readonly PlanService _planService;

        public PlanServiceTests()
        {
            _repositoryMock = new Mock<IPlanRepository>();
            _planService = new PlanService(_repositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerListaPlanes_DebeLlamarRepositorio()
        {
            // Arrange
            var planes = new List<PlanEntity> 
            { 
                new PlanEntity { Id = 1, Nombre = "Plan Basico" },
                new PlanEntity { Id = 2, Nombre = "Plan Premium" }
            };
            _repositoryMock.Setup(x => x.ObtenerListaPlanes()).ReturnsAsync(planes);

            // Act
            var resultado = await _planService.ObtenerListaPlanes();

            // Assert
            resultado.Should().NotBeNull();
            resultado.Should().HaveCount(2);
            _repositoryMock.Verify(x => x.ObtenerListaPlanes(), Times.Once);
        }
    }
}
