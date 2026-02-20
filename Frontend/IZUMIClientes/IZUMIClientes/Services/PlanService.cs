using IZUMIClientes_.Models;
using IZUMIClientes_.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IZUMIClientes_.Services
{
    public class PlanService : CommonService, IPlanService
    {
        private string _apiEndpoint;
        public PlanService(IConfiguration configuration) : base(configuration)
        {
            Configuration = configuration;
            _apiEndpoint = Configuration["HostWebAPIs:IZUMIAPI"];
        }

        #region GET
        public async Task<ResponseViewModel<List<PlanViewModel>>> ObtenerListaPlanes()
        {
            var urlConParametros = $"{_apiEndpoint}Plan/ObtenerListaPlanes";

            return JsonConvert.DeserializeObject<ResponseViewModel<List<PlanViewModel>>>(
                await GetRequestAsync(urlConParametros)
            );
        }
        #endregion
    }
}
