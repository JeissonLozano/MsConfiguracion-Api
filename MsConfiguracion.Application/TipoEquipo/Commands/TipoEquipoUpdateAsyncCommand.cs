using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.TipoEquipo.Commands
{
    public record TipoEquipoUpdateAsyncCommand(
       [Required] Guid Id,
       [Required] string NombreTipoEquipo,
       [Required] string Descripcion) : IRequest;
}
