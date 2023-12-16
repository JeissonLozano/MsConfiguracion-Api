using AutoMapper;
using MsCore.Domain.DTOs;

namespace MsCore.Application.Base
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>().ReverseMap();
        }
    }
}
