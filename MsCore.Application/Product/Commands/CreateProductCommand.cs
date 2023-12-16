using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Product.Commands
{
    public record CreateProductCommand(
       [Required] string Name,
       [Required] string Description,
       [Required] decimal Price,
       [Required] int Stock
    ) : IRequest;
}
