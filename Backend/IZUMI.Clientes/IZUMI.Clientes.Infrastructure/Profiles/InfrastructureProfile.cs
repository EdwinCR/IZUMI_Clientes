using AutoMapper;
using IZUMI.Clientes.Domain.Entities;
using IZUMI.Clientes.Infrastructure.Models;

namespace IZUMI.Clientes.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<ClienteModel, ClienteEntity>().ReverseMap();
            CreateMap<PlanModel, PlanEntity>().ReverseMap();
            CreateMap<TipoDocumentoModel, TipoDocumentoEntity>().ReverseMap();
        }
    }
}
