using AutoMapper;
using MediatR;
using MsCore.Domain.DTOs;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Product.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductService ProductService;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductService ProductService, IMapper mapper)
        {
            this.ProductService = ProductService;
            this.mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return mapper.Map<ProductDto>(await ProductService.GetProductsAsync(request.Id));
        }
    }
}
