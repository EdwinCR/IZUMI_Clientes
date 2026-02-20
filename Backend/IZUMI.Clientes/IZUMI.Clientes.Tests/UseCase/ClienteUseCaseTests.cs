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
    public class ClienteUseCaseTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IClienteService> _clienteServiceMock;
        private readonly Mock<ILogger<ClienteUseCase>> _loggerMock;
        private readonly ClienteUseCase _clienteUseCase;

        public ClienteUseCaseTests()
        {
            _mapperMock = new Mock<IMapper>();
            _clienteServiceMock = new Mock<IClienteService>();
            _loggerMock = new Mock<ILogger<ClienteUseCase>>();
            _clienteUseCase = new ClienteUseCase(_mapperMock.Object, _clienteServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task ObtenerListaClientes_DebeRetornarListaExitosamente()
        {
            // Arrange
            var clientes = new List<ClienteEntity> { new ClienteEntity { Id = Guid.NewGuid() } };
            var clientesDTO = new List<ClienteDTO> { new ClienteDTO { Id = Guid.NewGuid() } };
            
            _clienteServiceMock.Setup(x => x.ObtenerListaClientes()).ReturnsAsync(clientes);
            _mapperMock.Setup(x => x.Map<List<ClienteDTO>>(clientes)).Returns(clientesDTO);

            // Act
            var resultado = await _clienteUseCase.ObtenerListaClientes();

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task ObtenerClienteXId_DebeRetornarClienteExitosamente()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var cliente = new ClienteEntity { Id = clienteId };
            var clienteDTO = new ClienteDTO { Id = clienteId };
            
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId)).ReturnsAsync(cliente);
            _mapperMock.Setup(x => x.Map<ClienteDTO>(cliente)).Returns(clienteDTO);

            // Act
            var resultado = await _clienteUseCase.ObtenerClienteXId(clienteId);

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task CrearCliente_ClienteNoExiste_DebeCrearExitosamente()
        {
            // Arrange
            var request = new ClienteRequestDTO { TipoDocumentoId = 1, NumeroDocumento = "123456" };
            var clienteEntity = new ClienteEntity();
            
            _clienteServiceMock.Setup(x => x.ObtenerClientePorDocumento(request.TipoDocumentoId, request.NumeroDocumento))
                .ReturnsAsync((ClienteEntity)null);
            _mapperMock.Setup(x => x.Map<ClienteEntity>(request)).Returns(clienteEntity);

            // Act
            var resultado = await _clienteUseCase.CrearCliente(request);

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().Contain("correctamente");
        }

        [Fact]
        public async Task CrearCliente_ClienteExiste_DebeRetornarError()
        {
            // Arrange
            var request = new ClienteRequestDTO { TipoDocumentoId = 1, NumeroDocumento = "123456" };
            var clienteExistente = new ClienteEntity();
            
            _clienteServiceMock.Setup(x => x.ObtenerClientePorDocumento(request.TipoDocumentoId, request.NumeroDocumento))
                .ReturnsAsync(clienteExistente);

            // Act
            var resultado = await _clienteUseCase.CrearCliente(request);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("Ya existe");
        }

        [Fact]
        public async Task ActualizarCliente_ClienteExiste_DebeActualizarExitosamente()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var request = new ClienteUpdateRequestDTO { Id = clienteId };
            var clienteEntity = new ClienteEntity { Id = clienteId };
            
            _mapperMock.Setup(x => x.Map<ClienteEntity>(request)).Returns(clienteEntity);
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId)).ReturnsAsync(clienteEntity);

            // Act
            var resultado = await _clienteUseCase.ActualizarCliente(request);

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().Contain("actualizado correctamente");
        }

        [Fact]
        public async Task ActualizarCliente_ClienteNoExiste_DebeRetornarError()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var request = new ClienteUpdateRequestDTO { Id = clienteId };
            var clienteEntity = new ClienteEntity { Id = clienteId };
            
            _mapperMock.Setup(x => x.Map<ClienteEntity>(request)).Returns(clienteEntity);
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId)).ReturnsAsync((ClienteEntity)null);

            // Act
            var resultado = await _clienteUseCase.ActualizarCliente(request);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("no encontrado");
        }

        [Fact]
        public async Task ObtenerListaClientesPaginado_DebeRetornarResultadoPaginado()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 10;
            var pagedResult = new PagedResultEntity<ClienteEntity>
            {
                Data = new List<ClienteEntity> { new ClienteEntity { Id = Guid.NewGuid() } },
                TotalRecords = 25
            };
            var clientesDTO = new List<ClienteDTO> { new ClienteDTO { Id = Guid.NewGuid() } };
            
            _clienteServiceMock.Setup(x => x.ObtenerListaClientesPaginado(pageNumber, pageSize))
                .ReturnsAsync(pagedResult);
            _mapperMock.Setup(x => x.Map<List<ClienteDTO>>(pagedResult.Data)).Returns(clientesDTO);

            // Act
            var resultado = await _clienteUseCase.ObtenerListaClientesPaginado(pageNumber, pageSize);

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().NotBeNull();
            resultado.TotalRecords.Should().Be(25);
            resultado.TotalPages.Should().Be(3);
            resultado.PageNumber.Should().Be(1);
        }

        [Fact]
        public async Task ObtenerListaClientesPaginado_ConParametrosInvalidos_DebeValidarYCorregir()
        {
            // Arrange
            var pageNumber = -1;
            var pageSize = 500;
            var pagedResult = new PagedResultEntity<ClienteEntity>
            {
                Data = new List<ClienteEntity>(),
                TotalRecords = 0
            };
            
            _clienteServiceMock.Setup(x => x.ObtenerListaClientesPaginado(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(pagedResult);
            _mapperMock.Setup(x => x.Map<List<ClienteDTO>>(It.IsAny<List<ClienteEntity>>()))
                .Returns(new List<ClienteDTO>());

            // Act
            var resultado = await _clienteUseCase.ObtenerListaClientesPaginado(pageNumber, pageSize);

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.PageNumber.Should().Be(1);
            resultado.PageSize.Should().Be(100);
        }

        [Fact]
        public async Task EliminarCliente_ClienteExiste_DebeEliminarExitosamente()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var clienteExistente = new ClienteEntity { Id = clienteId };
            
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId)).ReturnsAsync(clienteExistente);
            _clienteServiceMock.Setup(x => x.EliminarCliente(clienteId)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _clienteUseCase.EliminarCliente(clienteId);

            // Assert
            resultado.Succeeded.Should().BeTrue();
            resultado.Data.Should().Contain("Eliminado");
        }

        [Fact]
        public async Task EliminarCliente_ClienteNoExiste_DebeRetornarError()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId)).ReturnsAsync((ClienteEntity)null);

            // Act
            var resultado = await _clienteUseCase.EliminarCliente(clienteId);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("no encontrado");
        }

        [Fact]
        public async Task ObtenerListaClientes_CuandoHayExcepcion_DebeRetornarError()
        {
            // Arrange
            _clienteServiceMock.Setup(x => x.ObtenerListaClientes())
                .ThrowsAsync(new Exception("Error de base de datos"));

            // Act
            var resultado = await _clienteUseCase.ObtenerListaClientes();

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }

        [Fact]
        public async Task ObtenerClienteXId_CuandoHayExcepcion_DebeRetornarError()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId))
                .ThrowsAsync(new Exception("Error de base de datos"));

            // Act
            var resultado = await _clienteUseCase.ObtenerClienteXId(clienteId);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }

        [Fact]
        public async Task CrearCliente_CuandoHayExcepcion_DebeRetornarError()
        {
            // Arrange
            var request = new ClienteRequestDTO { TipoDocumentoId = 1, NumeroDocumento = "123456" };
            
            _clienteServiceMock.Setup(x => x.ObtenerClientePorDocumento(It.IsAny<int>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Error de base de datos"));

            // Act
            var resultado = await _clienteUseCase.CrearCliente(request);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }

        [Fact]
        public async Task ActualizarCliente_CuandoHayExcepcion_DebeRetornarError()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var request = new ClienteUpdateRequestDTO { Id = clienteId };
            var clienteEntity = new ClienteEntity { Id = clienteId };
            
            _mapperMock.Setup(x => x.Map<ClienteEntity>(request)).Returns(clienteEntity);
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId))
                .ThrowsAsync(new Exception("Error de base de datos"));

            // Act
            var resultado = await _clienteUseCase.ActualizarCliente(request);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }

        [Fact]
        public async Task EliminarCliente_CuandoHayExcepcion_DebeRetornarError()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var clienteExistente = new ClienteEntity { Id = clienteId };
            
            _clienteServiceMock.Setup(x => x.ObtenerClienteXId(clienteId)).ReturnsAsync(clienteExistente);
            _clienteServiceMock.Setup(x => x.EliminarCliente(clienteId))
                .ThrowsAsync(new Exception("Error de base de datos"));

            // Act
            var resultado = await _clienteUseCase.EliminarCliente(clienteId);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }

        [Fact]
        public async Task ObtenerListaClientesPaginado_CuandoHayExcepcion_DebeRetornarError()
        {
            // Arrange
            _clienteServiceMock.Setup(x => x.ObtenerListaClientesPaginado(It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(new Exception("Error de base de datos"));

            // Act
            var resultado = await _clienteUseCase.ObtenerListaClientesPaginado(1, 10);

            // Assert
            resultado.Succeeded.Should().BeFalse();
            resultado.Message.Should().Contain("error en el procesamiento");
        }
    }
}
