using MediatR;
using MsCore.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Equipos.Queries
{
    public record GetEquiposByIdQuery([Required] Guid Id) : IRequest<EquiposDto>;
}
