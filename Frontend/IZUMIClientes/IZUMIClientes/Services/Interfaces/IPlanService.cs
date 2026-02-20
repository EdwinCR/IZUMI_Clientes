using IZUMIClientes_.Models;

namespace IZUMIClientes_.Services.Interfaces
{
    public interface IPlanService
    {
        Task<ResponseViewModel<List<PlanViewModel>>> ObtenerListaPlanes();
    }
}
