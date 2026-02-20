using IZUMI.Clientes.Application.DTO;

namespace IZUMI.Clientes.Application.UseCase.Interfaces
{
    public interface ITipoDocumentoUseCase
    {
        Task<ResponseDTO<List<TipoDocumentoDTO>>> ObtenerListaTipoDocumentos();
    }
}
