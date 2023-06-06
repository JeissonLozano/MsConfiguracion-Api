using MediatR;
using MsCore.Domain.DTOs;

namespace MsCore.Application.TipoEquipo.Queries
{
    public record GetAllTipoEquiposQuery : IRequest<IEnumerable<TipoEquipoDto>>;
}
