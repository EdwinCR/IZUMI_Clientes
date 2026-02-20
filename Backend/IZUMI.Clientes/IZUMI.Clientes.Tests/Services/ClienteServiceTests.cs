using FluentAssertions;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Domain.Services;
using Moq;

namespace IZUMI.Clientes.Tests.Services
{
    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> _repositoryMock;
        private readonly ClienteService _clienteService;

        public ClienteServiceTests()
        {
            _repositoryMock = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(_repositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerListaClientes_DebeLlamarRepositorio()
        {
            // Arrange
            var clientes = new List<ClienteEntity> { new ClienteEntity { Id = Guid.NewGuid() } };
            _repositoryMock.Setup(x => x.ObtenerListaClientes()).ReturnsAsync(clientes);

            // Act
            var resultado = await _clienteService.ObtenerListaClientes();

            // Assert
            resultado.Should().NotBeNull();
            resultado.Should().HaveCount(1);
            _repositoryMock.Verify(x => x.ObtenerListaClientes(), Times.Once);
        }

        [Fact]
        public async Task ObtenerListaClientesPaginado_DebeLlamarRepositorio()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 10;
            var pagedResult = new PagedResultEntity<ClienteEntity>
            {
                Data = new List<ClienteEntity> { new ClienteEntity { Id = Guid.NewGuid() } },
                TotalRecords = 25
            };
            _repositoryMock.Setup(x => x.ObtenerListaClientesPaginado(pageNumber, pageSize))
                .ReturnsAsync(pagedResult);

            // Act
            var resultado = await _clienteService.ObtenerListaClientesPaginado(pageNumber, pageSize);

            // Assert
            resultado.Should().NotBeNull();
            resultado.TotalRecords.Should().Be(25);
            _repositoryMock.Verify(x => x.ObtenerListaClientesPaginado(pageNumber, pageSize), Times.Once);
        }

        [Fact]
        public async Task ObtenerClienteXId_DebeLlamarRepositorio()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var cliente = new ClienteEntity { Id = clienteId };
            _repositoryMock.Setup(x => x.ObtenerClienteXId(clienteId)).ReturnsAsync(cliente);

            // Act
            var resultado = await _clienteService.ObtenerClienteXId(clienteId);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(clienteId);
            _repositoryMock.Verify(x => x.ObtenerClienteXId(clienteId), Times.Once);
        }

        [Fact]
        public async Task ObtenerClientePorDocumento_DebeLlamarRepositorio()
        {
            // Arrange
            var tipoDocumentoId = 1;
            var numeroDocumento = "123456";
            var cliente = new ClienteEntity { NumeroDocumento = numeroDocumento };
            _repositoryMock.Setup(x => x.ObtenerClientePorDocumento(tipoDocumentoId, numeroDocumento))
                .ReturnsAsync(cliente);

            // Act
            var resultado = await _clienteService.ObtenerClientePorDocumento(tipoDocumentoId, numeroDocumento);

            // Assert
            resultado.Should().NotBeNull();
            resultado.NumeroDocumento.Should().Be(numeroDocumento);
            _repositoryMock.Verify(x => x.ObtenerClientePorDocumento(tipoDocumentoId, numeroDocumento), Times.Once);
        }

        [Fact]
        public async Task CrearCliente_DebeLlamarRepositorio()
        {
            // Arrange
            var cliente = new ClienteEntity { Id = Guid.NewGuid() };
            _repositoryMock.Setup(x => x.CrearCliente(cliente)).Returns(Task.CompletedTask);

            // Act
            await _clienteService.CrearCliente(cliente);

            // Assert
            _repositoryMock.Verify(x => x.CrearCliente(cliente), Times.Once);
        }

        [Fact]
        public async Task ActualizarCliente_DebeLlamarRepositorio()
        {
            // Arrange
            var cliente = new ClienteEntity { Id = Guid.NewGuid() };
            _repositoryMock.Setup(x => x.ActualizarCliente(cliente)).Returns(Task.CompletedTask);

            // Act
            await _clienteService.ActualizarCliente(cliente);

            // Assert
            _repositoryMock.Verify(x => x.ActualizarCliente(cliente), Times.Once);
        }

        [Fact]
        public async Task EliminarCliente_DebeLlamarRepositorio()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            _repositoryMock.Setup(x => x.EliminarCliente(clienteId)).Returns(Task.CompletedTask);

            // Act
            await _clienteService.EliminarCliente(clienteId);

            // Assert
            _repositoryMock.Verify(x => x.EliminarCliente(clienteId), Times.Once);
        }
    }
}
