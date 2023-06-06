using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Equipos.Commands
{
    public record EquiposCreateCommand(
       [Required] string Codigo,
       [Required] string Estado,
       [Required] string Observaciones,
       [Required] Guid IdTipoEquipo
    ) : IRequest;
}
