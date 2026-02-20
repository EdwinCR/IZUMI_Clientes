using IZUMI.Clientes.Domain.Entities;

namespace IZUMI.Clientes.Domain.Services.Interfaces
{
    public interface ITipoDocumentoService
    {
        Task<List<TipoDocumentoEntity>> ObtenerListaTipoDocumentos();
    }
}
