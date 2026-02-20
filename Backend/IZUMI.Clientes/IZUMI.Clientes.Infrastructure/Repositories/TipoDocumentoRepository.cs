using AutoMapper;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IZUMI.Clientes.Infrastructure.Repositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        public TipoDocumentoRepository(IMapper mapper, Context context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoDocumentoEntity>> ObtenerListaTipoDocumentos()
        {
            var response = await _context.TipoDocumentoModels
                .Where(x => x.Activo).ToListAsync();

            return _mapper.Map<List<TipoDocumentoEntity>>(response);
        }
    }
}
