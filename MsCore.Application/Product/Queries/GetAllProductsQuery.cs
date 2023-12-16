using MediatR;
using MsCore.Domain.DTOs;

namespace MsCore.Application.Product.Queries
{
    public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;
}
