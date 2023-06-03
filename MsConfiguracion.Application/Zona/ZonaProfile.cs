using AutoMapper;
using MsConfiguracion.Domain.DTOs;

namespace MsConfiguracion.Application.Zona
{
    public class ZonaProfile : Profile
    {
        public ZonaProfile() 
        { 
            CreateMap<Domain.Entities.Zona, ZonaDto>().ReverseMap();
        }

    }
}
