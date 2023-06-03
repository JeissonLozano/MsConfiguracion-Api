using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.TipoEquipo.Commands
{
    public record TipoEquipoCreateCommand(
       [Required] string NombreTipoEquipo,
       [Required] string Descripcion
    ) : IRequest;
}
