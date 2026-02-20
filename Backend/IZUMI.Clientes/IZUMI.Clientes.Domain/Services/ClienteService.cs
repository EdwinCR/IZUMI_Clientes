using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Domain.Services.Interfaces;

namespace IZUMI.Clientes.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository=clienteRepository;
        }

        public async Task<List<ClienteEntity>> ObtenerListaClientes()
        {
            return await _clienteRepository.ObtenerListaClientes();
        }

        public async Task<PagedResultEntity<ClienteEntity>> ObtenerListaClientesPaginado(int pageNumber, int pageSize)
        {
            return await _clienteRepository.ObtenerListaClientesPaginado(pageNumber, pageSize);
        }

        public async Task<ClienteEntity> ObtenerClienteXId(Guid idCliente)
        {
            return await _clienteRepository.ObtenerClienteXId(idCliente);
        }

        public async Task<ClienteEntity> ObtenerClientePorDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            return await _clienteRepository.ObtenerClientePorDocumento(tipoDocumentoId, numeroDocumento);
        }

        public async Task CrearCliente(ClienteEntity cliente)
        {
            await _clienteRepository.CrearCliente(cliente);
        }
        public async Task ActualizarCliente(ClienteEntity cliente)
        {
            await _clienteRepository.ActualizarCliente(cliente);
        }

        public async Task EliminarCliente(Guid idCliente)
        {
            await _clienteRepository.EliminarCliente(idCliente);
        }
    }
}
