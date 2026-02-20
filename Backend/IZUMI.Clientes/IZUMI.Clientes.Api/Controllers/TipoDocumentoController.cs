using IZUMI.Clientes.Application.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IZUMI.Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/IZUMI/[controller]")]
    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoUseCase _tipoDocumentoUseCase;
        public TipoDocumentoController(ITipoDocumentoUseCase tipoDocumentoUseCase)
        {
            _tipoDocumentoUseCase = tipoDocumentoUseCase;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerListaTipoDocumentos()
        {
            var response = await _tipoDocumentoUseCase.ObtenerListaTipoDocumentos();

            if (!response.Succeeded)
            {
                return StatusCode(500, response);
            }

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound(new { message = "No se encontraron tipos de documento." });
            }

            return Ok(response);
        }
    }
}
