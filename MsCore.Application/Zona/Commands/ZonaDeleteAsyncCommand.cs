using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Zona.Commands
{
    public record ZonaDeleteAsyncCommand([Required] Guid Id) : IRequest;

}
