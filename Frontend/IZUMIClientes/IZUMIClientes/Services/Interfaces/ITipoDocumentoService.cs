using IZUMIClientes_.Models;

namespace IZUMIClientes_.Services.Interfaces
{
    public interface ITipoDocumentoService
    {
        Task<ResponseViewModel<List<TipoDocumentoViewModel>>> ObtenerListaTipoDocumentos();
    }
}
