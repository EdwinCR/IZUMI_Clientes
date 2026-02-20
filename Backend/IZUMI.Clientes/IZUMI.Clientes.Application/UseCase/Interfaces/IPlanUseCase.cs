using IZUMI.Clientes.Application.DTO;

namespace IZUMI.Clientes.Application.UseCase.Interfaces
{
    public interface IPlanUseCase
    {
        Task<ResponseDTO<List<PlanDTO>>> ObtenerListaPlanes();
    }
}
