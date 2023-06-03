using MediatR;
using MsConfiguracion.Domain.DTOs;

namespace MsConfiguracion.Application.Equipos.Queries
{
    public record GetAllEquipossQuery : IRequest<IEnumerable<EquiposDto>>;
}
