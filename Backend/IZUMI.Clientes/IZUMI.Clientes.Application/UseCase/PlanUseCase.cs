using AutoMapper;
using IZUMI.Clientes.Application.DTO;
using IZUMI.Clientes.Application.UseCase.Interfaces;
using IZUMI.Clientes.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace IZUMI.Clientes.Application.UseCase
{
    public class PlanUseCase : IPlanUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPlanService _planService;
        private readonly ILogger<PlanUseCase> _logger;

        public PlanUseCase(IMapper mapper, IPlanService planService, ILogger<PlanUseCase> logger)
        {
            _mapper = mapper;
            _planService = planService;
            _logger = logger;
        }

        public async Task<ResponseDTO<List<PlanDTO>>> ObtenerListaPlanes()
        {
            var respuesta = new ResponseDTO<List<PlanDTO>>();

            try
            {
                var planes = await _planService.ObtenerListaPlanes();
                respuesta.Data = _mapper.Map<List<PlanDTO>>(planes);
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de planes");
                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }
    }
}
