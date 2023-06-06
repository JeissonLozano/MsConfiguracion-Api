using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Zona.Commands
{
    public record ZonaCreateCommand(
    [Required] string Nombre,
    [Required] string Descripcion,
    [Required] string Estado
    ) : IRequest;


}
