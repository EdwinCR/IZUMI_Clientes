using AutoMapper;
using IZUMI.Clientes.Application.DTO;
using IZUMI.Clientes.Domain.Entities;

namespace IZUMI.Clientes.Application.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ClienteDTO, ClienteEntity>().ReverseMap();
            CreateMap<ClienteRequestDTO, ClienteEntity>().ReverseMap();
            CreateMap<ClienteUpdateRequestDTO, ClienteEntity>().ReverseMap();
            CreateMap<PlanDTO, PlanEntity>().ReverseMap();
            CreateMap<TipoDocumentoDTO, TipoDocumentoEntity>().ReverseMap();
        }
    }
}
