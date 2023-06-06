using AutoMapper;
using MsCore.Domain.DTOs;

namespace MsCore.Application.Base
{
    public class TipoEquipoProfile : Profile
    {
        public TipoEquipoProfile()
        {
            CreateMap<Domain.Entities.TipoEquipo, TipoEquipoDto>().ReverseMap();
        }
    }
}
