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
    public class TipoDocumentoUseCaseTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITipoDocumentoService> _tipoDocumentoServiceMock;
        private readonly Mock<ILogger<TipoDocumentoUseCase>> _loggerMock;
        private readonly TipoDocumentoUseCase _tipoDocumentoUseCase;

        public TipoDocumentoUseCaseTests()
        {
            _mapperMock = new Mock<IMapper>();
            _tipoDocumentoServiceMock = new Mock<ITipoDocumentoService>();
            _loggerMock = new Mock<ILogger<TipoDocumentoUseCase>>();
            _tipoDocumentoUseCase = new TipoDocumentoUseCase(_mapperMock.Object, _tipoDocumentoServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task ObtenerListaTipoDocumentos_DebeRetornarListaExitosamente()
        {
            // Arrange
            var tipoDocumentos = new List<TipoDocumentoEntity> 
            { 
                new TipoDocumentoEntity { Id = 1, Nombre = "CC" },
                new TipoDocumentoEntity { Id = 2, Nombre = "CE" }
            };
            var tipoDocumentosDTO = new List<TipoDocumentoDTO> 
            { 
                new TipoDocumentoDTO { Id = 1, Nombre = "CC" },
                new TipoDocumentoDTO { Id = 2, Nombre = "CE" }
            };
            
            _tipoDocumentoServiceMock.Setup(x => x.ObtenerListaTipoDocumentos()).ReturnsAsync(tipoDocumentos);
            _mapperMock.Setup(x => x.Map<List<TipoDocumentoDTO>>(tipoDocumentos)).Returns(tipoDocumentosDTO);

            // Act
            var resultado = await _tipoDocumentoUseCase.ObtenerListaTipoDocumentos();

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().NotBeNull();
            resultado.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task ObtenerListaTipoDocumentos_CuandoHayError_DebeRetornarErrorResponse()
        {
            // Arrange
            _tipoDocumentoServiceMock.Setup(x => x.ObtenerListaTipoDocumentos())
                .ThrowsAsync(new Exception("Error de BD"));

            // Act
            var resultado = await _tipoDocumentoUseCase.ObtenerListaTipoDocumentos();

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }
    }
}
