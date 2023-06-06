using AutoMapper;
using MsCore.Domain.DTOs;

namespace MsCore.Application.Zona
{
    public class ZonaProfile : Profile
    {
        public ZonaProfile() 
        { 
            CreateMap<Domain.Entities.Zona, ZonaDto>().ReverseMap();
        }

    }
}
