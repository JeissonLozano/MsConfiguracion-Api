using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Product.Commands
{
    public record UpdateProductAsyncCommand(
       [Required] Guid Id,
       [Required] string Name,
       [Required] string Description,
       [Required] decimal Price,
       [Required] int Stock) : IRequest;
}
