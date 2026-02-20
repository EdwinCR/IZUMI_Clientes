using IZUMIClientes_.Models;

namespace IZUMIClientes_.Services.Interfaces
{
    public interface IClienteService
    {
        Task<PagedResponseViewModel<ClienteViewModel>> ObtenerListaClientePaginada(int pagina, int tamanioPagina);
        Task<ResponseViewModel<ClienteViewModel>> ObtenerClienteXId(Guid idCliente);
        Task<ResponseViewModel<string>> CrearCliente(ClienteRequestViewModel request);
        Task<ResponseViewModel<string>> ActualizarCliente(Guid idCliente, ClienteUpdateRequestViewModel request);
        Task<ResponseViewModel<string>> EliminarCliente(Guid idCliente);
    }
}
