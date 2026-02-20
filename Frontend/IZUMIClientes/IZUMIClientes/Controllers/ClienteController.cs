using IZUMIClientes_.Models;
using IZUMIClientes_.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace IZUMIClientes_.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private IConfiguration _configuration;
        private readonly IClienteService _clienteService;
        private readonly IPlanService _planService;
        private readonly ITipoDocumentoService _tipoDocumentoService;

        public ClienteController(ILogger<ClienteController> logger, 
            IClienteService clienteService,
            IPlanService planService,
            ITipoDocumentoService tipoDocumentoService)
        {
            _logger = logger;
            _clienteService = clienteService;
            _planService=planService;
            _tipoDocumentoService=tipoDocumentoService;
        }

        public async Task<IActionResult> Index(int pagina = 1)
        {
            int tamanioPagina = 5;

            var clientes = await _clienteService.ObtenerListaClientePaginada(pagina, tamanioPagina);

            var model = new ListaPaginadaViewModel<ClienteViewModel>
            {
                Items = clientes.Data == null ? new List<ClienteViewModel>() : clientes.Data,
                NumeroPagina = tamanioPagina,
                TotalPaginas = clientes.TotalPages
            };

            TempData["MensajeExito"] = null;
            TempData["MensajeError"] = null;

            return View(model);

        }

        public async Task<IActionResult> Crear()
        {
            var tiposResponse = await _tipoDocumentoService.ObtenerListaTipoDocumentos();
            var planesResponse = await _planService.ObtenerListaPlanes();

            var model = new ClienteViewModel
            {
                TiposDocumento = tiposResponse.Succeeded ? tiposResponse.Data : new List<TipoDocumentoViewModel>(),
                Planes = planesResponse.Succeeded ? planesResponse.Data : new List<PlanViewModel>()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ClienteViewModel model)
        {

            var tiposResponse = await _tipoDocumentoService.ObtenerListaTipoDocumentos();
            var planesResponse = await _planService.ObtenerListaPlanes();

            model.TiposDocumento = tiposResponse.Succeeded ? tiposResponse.Data : new List<TipoDocumentoViewModel>();
            model.Planes = planesResponse.Succeeded ? planesResponse.Data : new List<PlanViewModel>();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modeloCrear = new ClienteRequestViewModel
            {
                TipoDocumentoId = model.TipoDocumentoId,
                NumeroDocumento = model.NumeroDocumento,
                FechaNacimiento = model.FechaNacimiento,
                PrimerNombre = model.PrimerNombre,
                SegundoNombre = model.SegundoNombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Direccion = model.Direccion,
                Celular = model.Celular,
                Email = model.Email,
                PlanId = model.PlanId
            };

            var resultado = await _clienteService.CrearCliente(modeloCrear);

            if (resultado.Succeeded)
            {
                TempData["MensajeExito"] = "Cliente guardado correctamente.";
                TempData["MensajeError"] = null;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["MensajeError"] = resultado.Message;
            }

                ModelState.AddModelError(string.Empty, resultado.Message);
            return View(model);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var cliente = await _clienteService.ObtenerClienteXId(id);

            var tiposResponse = await _tipoDocumentoService.ObtenerListaTipoDocumentos();
            var planesResponse = await _planService.ObtenerListaPlanes();

            if (cliente == null)
                return NotFound();

            cliente.Data.TiposDocumento = tiposResponse.Succeeded ? tiposResponse.Data : new List<TipoDocumentoViewModel>();
            cliente.Data.Planes = planesResponse.Succeeded ? planesResponse.Data : new List<PlanViewModel>();

            return View(cliente.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ClienteViewModel model)
        {
            var tiposResponse = await _tipoDocumentoService.ObtenerListaTipoDocumentos();
            var planesResponse = await _planService.ObtenerListaPlanes();

            model.TiposDocumento = tiposResponse.Succeeded ? tiposResponse.Data : new List<TipoDocumentoViewModel>();
            model.Planes = planesResponse.Succeeded ? planesResponse.Data : new List<PlanViewModel>();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modeloActualizar = new ClienteUpdateRequestViewModel
            {
                Id = model.Id,
                TipoDocumentoId = model.TipoDocumentoId,
                NumeroDocumento = model.NumeroDocumento,
                FechaNacimiento = model.FechaNacimiento,
                PrimerNombre = model.PrimerNombre,
                SegundoNombre = model.SegundoNombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Direccion = model.Direccion,
                Celular = model.Celular,
                Email = model.Email,
                PlanId = model.PlanId
            };

            var resultado = await _clienteService.ActualizarCliente(model.Id, modeloActualizar);

            if (resultado.Succeeded)
            {
                TempData["MensajeExito"] = "Cliente editado correctamente.";
                TempData["MensajeError"] = null;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["MensajeError"] = resultado.Message;
            }

            ModelState.AddModelError(string.Empty, resultado.Message);
            return View(model);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(Guid id)
        {
            var resultado = await _clienteService.EliminarCliente(id);

            if (resultado.Succeeded)
            {
                TempData["MensajeExito"] = "Cliente eliminado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            TempData["MensajeError"] = $"Error al eliminar cliente: {resultado.Message}";
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
