using IZUMI.Clientes.Domain.Entities;

namespace IZUMI.Clientes.Domain.IRepositories
{
    public interface ITipoDocumentoRepository
    {
        Task<List<TipoDocumentoEntity>> ObtenerListaTipoDocumentos();
    }
}
