using IZUMI.Clientes.Application.DTO;
using IZUMI.Clientes.Application.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IZUMI.Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/IZUMI/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteUseCase _clienteUseCase;
        public ClienteController(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerListaClientes()
        {
            var response = await _clienteUseCase.ObtenerListaClientes();

            if (!response.Succeeded)
            {
                return StatusCode(500, response);
            }

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound(new { message = "No se encontraron clientes." });
            }

            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> ObtenerClienteXId(Guid id)
        {
            var response = await _clienteUseCase.ObtenerClienteXId(id);

            if (!response.Succeeded)
            {
                return StatusCode(500, response);
            }

            if (response.Data == null)
            {
                return NotFound(new { message = "Cliente no encontrado." });
            }

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteRequestDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _clienteUseCase.CrearCliente(cliente);

            if (!response.Succeeded)
                return StatusCode(500, response);

            return Ok(response);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ActualizarCliente(Guid id, [FromBody] ClienteUpdateRequestDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cliente.Id = id;

            var response = await _clienteUseCase.ActualizarCliente(cliente);

            if (!response.Succeeded)
            {
                if (response.Message.Contains("no encontrado"))
                    return NotFound(response);

                return StatusCode(500, response);
            }

            return Ok(response); 
        }

        [HttpGet("[action]/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> ObtenerListaClientesPaginado(int pageNumber = 1, int pageSize = 10)
        {
            var response = await _clienteUseCase.ObtenerListaClientesPaginado(pageNumber, pageSize);

            if (!response.Succeeded)
            {
                return StatusCode(500, response);
            }

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound(new { message = "No se encontraron clientes." });
            }

            return Ok(response);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> EliminarCliente(Guid id)
        {
            var response = await _clienteUseCase.EliminarCliente(id);

            if (!response.Succeeded)
            {
                if (response.Message.Contains("no encontrado"))
                    return NotFound(response);

                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}
