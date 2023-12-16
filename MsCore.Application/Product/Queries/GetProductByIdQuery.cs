using MediatR;
using MsCore.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Product.Queries
{
    public record GetProductByIdQuery([Required] Guid Id) : IRequest<ProductDto>;
}
