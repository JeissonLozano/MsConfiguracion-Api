using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.TipoEquipo.Commands
{
    public record TipoEquipoDeleteAsyncCommand([Required] Guid Id) : IRequest;
}
