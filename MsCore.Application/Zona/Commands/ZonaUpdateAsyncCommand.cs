using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Zona.Commands
{
    public record ZonaUpdateAsyncCommand(
    [Required] Guid Id,
    [Required] string Nombre,
    [Required] string Descripcion,
    [Required] string Estado) : IRequest;

}
