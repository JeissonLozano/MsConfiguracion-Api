using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.Zona.Commands
{
    public record ZonaCreateCommand(
    [Required] string Nombre,
    [Required] string Descripcion,
    [Required] string Estado
    ) : IRequest;


}
