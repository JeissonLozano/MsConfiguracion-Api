using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.Equipos.Commands
{
    public record EquiposDeleteAsyncCommand([Required] Guid Id) : IRequest;
}
