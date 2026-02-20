using AutoMapper;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IZUMI.Clientes.Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        public PlanRepository(IMapper mapper, Context context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlanEntity>> ObtenerListaPlanes()
        {
            var response = await _context.PlanModels
                .Where(x => x.Activo).ToListAsync();

            return _mapper.Map<List<PlanEntity>>(response);
        }
    }
}
