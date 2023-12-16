using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Product.Commands
{
    public record DeleteProductAsyncCommand([Required] Guid Id) : IRequest;
}
