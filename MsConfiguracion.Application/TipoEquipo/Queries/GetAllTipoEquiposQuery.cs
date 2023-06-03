using MediatR;
using MsConfiguracion.Domain.DTOs;

namespace MsConfiguracion.Application.TipoEquipo.Queries
{
    public record GetAllTipoEquiposQuery : IRequest<IEnumerable<TipoEquipoDto>>;
}
