using MediatR;
using MsCore.Domain.DTOs;

namespace MsCore.Application.Equipos.Queries
{
    public record GetAllEquipossQuery : IRequest<IEnumerable<EquiposDto>>;
}
