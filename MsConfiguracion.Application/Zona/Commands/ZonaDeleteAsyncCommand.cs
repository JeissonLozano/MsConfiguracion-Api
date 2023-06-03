using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.Zona.Commands
{
    public record ZonaDeleteAsyncCommand([Required] Guid Id) : IRequest;

}
