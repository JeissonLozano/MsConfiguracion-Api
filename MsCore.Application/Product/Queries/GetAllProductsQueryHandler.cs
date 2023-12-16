using AutoMapper;
using MediatR;
using MsCore.Domain.DTOs;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Product.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductService ProductService;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IProductService ProductService, IMapper mapper)
        {
            this.ProductService = ProductService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return mapper.Map<IEnumerable<ProductDto>>(await ProductService.GetAllEquipossAsync());
        }
    }
}
