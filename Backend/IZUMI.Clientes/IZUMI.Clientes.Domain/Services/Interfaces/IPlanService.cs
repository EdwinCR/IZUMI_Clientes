using IZUMI.Clientes.Domain.Entities;

namespace IZUMI.Clientes.Domain.Services.Interfaces
{
    public interface IPlanService
    {
        Task<List<PlanEntity>> ObtenerListaPlanes();
    }
}
