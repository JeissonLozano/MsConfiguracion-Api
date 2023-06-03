using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.TipoEquipo.Commands
{
    public record TipoEquipoDeleteAsyncCommand([Required] Guid Id) : IRequest;
}
