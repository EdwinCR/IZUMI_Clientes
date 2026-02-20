using FluentAssertions;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Domain.Services;
using Moq;

namespace IZUMI.Clientes.Tests.Services
{
    public class TipoDocumentoServiceTests
    {
        private readonly Mock<ITipoDocumentoRepository> _repositoryMock;
        private readonly TipoDocumentoService _tipoDocumentoService;

        public TipoDocumentoServiceTests()
        {
            _repositoryMock = new Mock<ITipoDocumentoRepository>();
            _tipoDocumentoService = new TipoDocumentoService(_repositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerListaTipoDocumentos_DebeLlamarRepositorio()
        {
            // Arrange
            var tipoDocumentos = new List<TipoDocumentoEntity> 
            { 
                new TipoDocumentoEntity { Id = 1, Nombre = "CC" },
                new TipoDocumentoEntity { Id = 2, Nombre = "CE" }
            };
            _repositoryMock.Setup(x => x.ObtenerListaTipoDocumentos()).ReturnsAsync(tipoDocumentos);

            // Act
            var resultado = await _tipoDocumentoService.ObtenerListaTipoDocumentos();

            // Assert
            resultado.Should().NotBeNull();
            resultado.Should().HaveCount(2);
            _repositoryMock.Verify(x => x.ObtenerListaTipoDocumentos(), Times.Once);
        }
    }
}
