using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.Equipos.Commands
{
    public record EquiposUpdateAsyncCommand(
       [Required] Guid Id,
       [Required] string Codigo,
       [Required] string Estado,
       [Required] string Observaciones,
       [Required] Guid IdTipoEquipo) : IRequest;
}
