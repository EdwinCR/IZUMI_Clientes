using IZUMI.Clientes.Domain.Entities;

namespace IZUMI.Clientes.Domain.IRepositories
{
    public interface IClienteRepository
    {
        Task<List<ClienteEntity>> ObtenerListaClientes();
        Task<PagedResultEntity<ClienteEntity>> ObtenerListaClientesPaginado(int pageNumber, int pageSize);
        Task<ClienteEntity> ObtenerClienteXId(Guid idCliente);
        Task<ClienteEntity> ObtenerClientePorDocumento(int tipoDocumentoId, string numeroDocumento);
        Task CrearCliente(ClienteEntity cliente);
        Task ActualizarCliente(ClienteEntity cliente);
        Task EliminarCliente(Guid idCliente);
    }
}
