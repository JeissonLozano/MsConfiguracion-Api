using MediatR;
using MsConfiguracion.Domain.DTOs;

namespace MsConfiguracion.Application.Zona.Queries
{
    public record GetAllZonaQuery : IRequest<IEnumerable<ZonaDto>>;
}
