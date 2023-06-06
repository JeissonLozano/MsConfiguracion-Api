using AutoMapper;
using MsCore.Domain.DTOs;

namespace MsCore.Application.Base
{
    public class EquiposProfile : Profile
    {
        public EquiposProfile()
        {
            CreateMap<Domain.Entities.Equipo, EquiposDto>()
                .ForMember(x => x.NombreTipoEquipo, TipoEquipo => TipoEquipo.MapFrom(x => x.TipoEquipo.NombreTipoEquipo))
                .ReverseMap();
        }
    }
}
