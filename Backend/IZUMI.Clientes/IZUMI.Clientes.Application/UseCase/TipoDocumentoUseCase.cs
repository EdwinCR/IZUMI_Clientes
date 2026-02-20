using AutoMapper;
using IZUMI.Clientes.Application.DTO;
using IZUMI.Clientes.Application.UseCase.Interfaces;
using IZUMI.Clientes.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace IZUMI.Clientes.Application.UseCase
{
    public class TipoDocumentoUseCase : ITipoDocumentoUseCase
    {
        private readonly IMapper _mapper;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly ILogger<TipoDocumentoUseCase> _logger;

        public TipoDocumentoUseCase(IMapper mapper, ITipoDocumentoService tipoDocumentoService, ILogger<TipoDocumentoUseCase> logger)
        {
            _mapper = mapper;
            _tipoDocumentoService = tipoDocumentoService;
            _logger = logger;
        }

        public async Task<ResponseDTO<List<TipoDocumentoDTO>>> ObtenerListaTipoDocumentos()
        {
            var respuesta = new ResponseDTO<List<TipoDocumentoDTO>>();

            try
            {
                var planes = await _tipoDocumentoService.ObtenerListaTipoDocumentos();
                respuesta.Data = _mapper.Map<List<TipoDocumentoDTO>>(planes);
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de tipo de documentos");
                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }
    }
}
