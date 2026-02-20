using AutoMapper;
using IZUMI.Clientes.Application.DTO;
using IZUMI.Clientes.Application.UseCase.Interfaces;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace IZUMI.Clientes.Application.UseCase
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClienteUseCase> _logger;

        public ClienteUseCase(IMapper mapper, IClienteService clienteService, ILogger<ClienteUseCase> logger)
        {
            _mapper = mapper;
            _clienteService = clienteService;
            _logger = logger;
        }

        public async Task<ResponseDTO<List<ClienteDTO>>> ObtenerListaClientes()
        {
            var respuesta = new ResponseDTO<List<ClienteDTO>>();

            try
            {
                var clientes = await _clienteService.ObtenerListaClientes();
                respuesta.Data = _mapper.Map<List<ClienteDTO>>(clientes);
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de clientes");
                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }

        public async Task<PagedResponseDTO<ClienteDTO>> ObtenerListaClientesPaginado(int pageNumber, int pageSize)
        {
            var respuesta = new PagedResponseDTO<ClienteDTO>();

            try
            {
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 100) pageSize = 100;

                var resultado = await _clienteService.ObtenerListaClientesPaginado(pageNumber, pageSize);
                
                respuesta.Data = _mapper.Map<List<ClienteDTO>>(resultado.Data);
                respuesta.TotalRecords = resultado.TotalRecords;
                respuesta.PageNumber = pageNumber;
                respuesta.PageSize = pageSize;
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de clientes paginada");
                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }

        public async Task<ResponseDTO<ClienteDTO>> ObtenerClienteXId(Guid idCliente)
        {
            var respuesta = new ResponseDTO<ClienteDTO>();

            try
            {
                var cliente = await _clienteService.ObtenerClienteXId(idCliente);
                respuesta.Data = _mapper.Map<ClienteDTO>(cliente);
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener cliente por Id");
                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }

        public async Task<ResponseDTO<string>> CrearCliente(ClienteRequestDTO cliente)
        {
            var respuesta = new ResponseDTO<string>();

            try
            {
                var clienteExistente = await _clienteService.ObtenerClientePorDocumento(
                    cliente.TipoDocumentoId,
                    cliente.NumeroDocumento
                );

                if (clienteExistente != null)
                {
                    respuesta.Succeeded = false;
                    respuesta.Message = "Ya existe un cliente registrado con ese tipo y número de documento.";
                    return respuesta;
                }

                var clienteEntity = _mapper.Map<ClienteEntity>(cliente);
                clienteEntity.FechaCreacion = DateTime.UtcNow;
                clienteEntity.Activo = true;

                await _clienteService.CrearCliente(clienteEntity);

                respuesta.Data = "Cliente creado correctamente";
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear cliente");
                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }

        public async Task<ResponseDTO<string>> ActualizarCliente(ClienteUpdateRequestDTO cliente)
        {
            var respuesta = new ResponseDTO<string>();

            try
            {
                var clienteEntity = _mapper.Map<ClienteEntity>(cliente);

                var clienteExistente = await _clienteService.ObtenerClienteXId(clienteEntity.Id);

                if (clienteExistente == null)
                {
                    respuesta.Succeeded = false;
                    respuesta.Message = "Cliente no encontrado.";
                    return respuesta;
                }
                await _clienteService.ActualizarCliente(clienteEntity);

                respuesta.Data = "Cliente actualizado correctamente";
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar cliente");

                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }

        public async Task<ResponseDTO<string>> EliminarCliente(Guid idCliente)
        {
            var respuesta = new ResponseDTO<string>();

            try
            {
                var clienteExistente = await _clienteService.ObtenerClienteXId(idCliente);

                if (clienteExistente == null)
                {
                    respuesta.Succeeded = false;
                    respuesta.Message = "Cliente no encontrado.";
                    return respuesta;
                }

                await _clienteService.EliminarCliente(idCliente);
                respuesta.Data = "Cliente Eliminado";
                respuesta.Succeeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar cliente");
                respuesta.Succeeded = false;
                respuesta.Message = "Se presentó un error en el procesamiento de la solicitud.";
            }

            return respuesta;
        }
    }
}
