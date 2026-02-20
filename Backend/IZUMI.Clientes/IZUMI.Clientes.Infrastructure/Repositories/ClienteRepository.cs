using AutoMapper;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Infrastructure.Contexts;
using IZUMI.Clientes.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace IZUMI.Clientes.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        public ClienteRepository(IMapper mapper, Context context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClienteEntity>> ObtenerListaClientes()
        {
            var response = await _context.ClienteModels
                .Where(x => x.Activo)
                .Include(c => c.Plan)
                .Include(c => c.TipoDocumento)
                .ToListAsync();

            return _mapper.Map<List<ClienteEntity>>(response);
        }

        public async Task<PagedResultEntity<ClienteEntity>> ObtenerListaClientesPaginado(int pageNumber, int pageSize)
        {
            var query = _context.ClienteModels
                .Where(x => x.Activo)
                .Include(c => c.Plan)
                .Include(c => c.TipoDocumento);

            var totalRecords = await query.CountAsync();

            var clientes = await query
                .OrderBy(c => c.FechaCreacion)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResultEntity<ClienteEntity>
            {
                Data = _mapper.Map<List<ClienteEntity>>(clientes),
                TotalRecords = totalRecords
            };
        }

        public async Task<ClienteEntity> ObtenerClienteXId(Guid idCliente)
        {
            var response = await _context.ClienteModels
                .Where(x => x.Activo && x.Id == idCliente)
                .Include(c => c.Plan)
                .Include(c => c.TipoDocumento)
                .FirstOrDefaultAsync();

            return _mapper.Map<ClienteEntity>(response);
        }

        public async Task<ClienteEntity> ObtenerClientePorDocumento(int tipoDocumentoId, string numeroDocumento)
        {
            var response = await _context.ClienteModels
                .FirstOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento && x.TipoDocumentoId == tipoDocumentoId);

            return _mapper.Map<ClienteEntity>(response);
        }

        public async Task CrearCliente(ClienteEntity cliente)
        {
            var clienteModel = _mapper.Map<ClienteModel>(cliente);

            await _context.AddAsync(clienteModel);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarCliente(ClienteEntity cliente)
        {
            var clienteModel = _mapper.Map<ClienteModel>(cliente);

            var model = await _context.ClienteModels.FirstOrDefaultAsync(x => x.Id == clienteModel.Id);

            if (model == null) return;


            model.TipoDocumentoId = clienteModel.TipoDocumentoId;
            model.NumeroDocumento = clienteModel.NumeroDocumento;
            model.FechaNacimiento = clienteModel.FechaNacimiento;
            model.PrimerNombre = clienteModel.PrimerNombre;
            model.SegundoNombre = clienteModel.SegundoNombre;
            model.PrimerApellido = clienteModel.PrimerApellido;
            model.SegundoApellido = clienteModel.SegundoApellido;
            model.Direccion = clienteModel.Direccion;
            model.Celular = clienteModel.Celular;
            model.Email = clienteModel.Email;
            model.PlanId = clienteModel.PlanId;
            _context.ClienteModels.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCliente(Guid idCliente)
        {

            var model = await _context.ClienteModels.FirstOrDefaultAsync(x => x.Id == idCliente);

            if (model == null) return;


            model.Activo = false;

            _context.ClienteModels.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
