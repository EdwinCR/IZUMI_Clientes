using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Domain.Services.Interfaces;

namespace IZUMI.Clientes.Domain.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        public async Task<List<TipoDocumentoEntity>> ObtenerListaTipoDocumentos()
        {
            return await _tipoDocumentoRepository.ObtenerListaTipoDocumentos();
        }
    }
}
