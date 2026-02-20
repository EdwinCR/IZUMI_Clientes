using IZUMI.Clientes.Application.DTO;

namespace IZUMI.Clientes.Application.UseCase.Interfaces
{
    public interface IClienteUseCase
    {
        Task<ResponseDTO<List<ClienteDTO>>> ObtenerListaClientes();
        Task<PagedResponseDTO<ClienteDTO>> ObtenerListaClientesPaginado(int pageNumber, int pageSize);
        Task<ResponseDTO<ClienteDTO>> ObtenerClienteXId(Guid idCliente);
        Task<ResponseDTO<string>> CrearCliente(ClienteRequestDTO cliente);
        Task<ResponseDTO<string>> ActualizarCliente(ClienteUpdateRequestDTO cliente);
        Task<ResponseDTO<string>> EliminarCliente(Guid idCliente);
    }
}
