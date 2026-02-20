using IZUMI.Clientes.Domain.Entities;

namespace IZUMI.Clientes.Domain.IRepositories
{
    public interface IPlanRepository
    {
        Task<List<PlanEntity>> ObtenerListaPlanes();
    }
}
