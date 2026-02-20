using IZUMIClientes_.Models;
using IZUMIClientes_.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IZUMIClientes_.Services
{
    public class TipoDocumentoService : CommonService, ITipoDocumentoService
    {
        private string _apiEndpoint;
        public TipoDocumentoService(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
            _apiEndpoint = Configuration["HostWebAPIs:IZUMIAPI"];
        }

        #region GET
        public async Task<ResponseViewModel<List<TipoDocumentoViewModel>>> ObtenerListaTipoDocumentos()
        {
            var urlConParametros = $"{_apiEndpoint}TipoDocumento/ObtenerListaTipoDocumentos";

            return JsonConvert.DeserializeObject<ResponseViewModel<List<TipoDocumentoViewModel>>>(
                await GetRequestAsync(urlConParametros)
            );
        }
        #endregion
    }
}
