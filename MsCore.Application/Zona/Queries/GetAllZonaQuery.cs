using MediatR;
using MsCore.Domain.DTOs;

namespace MsCore.Application.Zona.Queries
{
    public record GetAllZonaQuery : IRequest<IEnumerable<ZonaDto>>;
}
