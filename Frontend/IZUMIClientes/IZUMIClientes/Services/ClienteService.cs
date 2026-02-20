using IZUMIClientes_.Models;
using IZUMIClientes_.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IZUMIClientes_.Services
{
    public class ClienteService : CommonService, IClienteService
    {
        private string _apiEndpoint;
        public ClienteService(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
            _apiEndpoint = Configuration["HostWebAPIs:IZUMIAPI"];
        }

        #region GET
        public async Task<PagedResponseViewModel<ClienteViewModel>> ObtenerListaClientePaginada(int pagina, int tamanioPagina)
        {
            var urlConParametros = $"{_apiEndpoint}Cliente/ObtenerListaClientesPaginado/{pagina}/{tamanioPagina}";

            return JsonConvert.DeserializeObject<PagedResponseViewModel<ClienteViewModel>>(
                await GetRequestAsync(urlConParametros)
            );
        }

        public async Task<ResponseViewModel<ClienteViewModel>> ObtenerClienteXId(Guid idCliente)
        {
            var urlConParametros = $"{_apiEndpoint}Cliente/ObtenerClienteXId/{idCliente}";

            return JsonConvert.DeserializeObject<ResponseViewModel<ClienteViewModel>>(
                await GetRequestAsync(urlConParametros)
            );
        }
        #endregion

        #region POST
        public async Task<ResponseViewModel<string>> CrearCliente(ClienteRequestViewModel request)
        {
            var url = $"{_apiEndpoint}Cliente/CrearCliente";

            return JsonConvert.DeserializeObject<ResponseViewModel<string>>(
                await PostContent(url, request)
            );
        }
        #endregion

        #region PUT
        public async Task<ResponseViewModel<string>> ActualizarCliente(Guid idCliente, ClienteUpdateRequestViewModel request)
        {
            var url = $"{_apiEndpoint}Cliente/ActualizarCliente/{idCliente}";

            return JsonConvert.DeserializeObject<ResponseViewModel<string>>(
                await PutContent(url, request)
            );
        }
        #endregion

        #region DELETE
        public async Task<ResponseViewModel<string>> EliminarCliente(Guid idCliente)
        {
            var url = $"{_apiEndpoint}Cliente/EliminarCliente/{idCliente}";

            return JsonConvert.DeserializeObject<ResponseViewModel<string>>(
                await DeleteRequestAsync(url)
            );
        }
        #endregion
    }
}
