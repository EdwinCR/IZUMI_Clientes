using IZUMI.Clientes.Application.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IZUMI.Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/IZUMI/[controller]")]
    public class PlanController : Controller
    {
        private readonly IPlanUseCase _planUseCase;
        public PlanController(IPlanUseCase planUseCase)
        {
            _planUseCase = planUseCase;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerListaPlanes()
        {
            var response = await _planUseCase.ObtenerListaPlanes();

            if (!response.Succeeded)
            {
                return StatusCode(500, response);
            }

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound(new { message = "No se encontraron planes." });
            }

            return Ok(response);
        }
    }
}
