using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Domain.Services.Interfaces;

namespace IZUMI.Clientes.Domain.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        public PlanService(IPlanRepository planRepository)
        {
            _planRepository=planRepository;
        }

        public async Task<List<PlanEntity>> ObtenerListaPlanes()
        {
            return await _planRepository.ObtenerListaPlanes();
        }
    }
}
