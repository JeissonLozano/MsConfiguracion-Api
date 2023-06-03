using AutoMapper;
using MsConfiguracion.Domain.DTOs;

namespace MsConfiguracion.Application.Base
{
    public class TipoEquipoProfile : Profile
    {
        public TipoEquipoProfile()
        {
            CreateMap<Domain.Entities.TipoEquipo, TipoEquipoDto>().ReverseMap();
        }
    }
}
