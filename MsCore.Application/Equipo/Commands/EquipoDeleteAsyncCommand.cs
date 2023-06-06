using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Equipos.Commands
{
    public record EquiposDeleteAsyncCommand([Required] Guid Id) : IRequest;
}
