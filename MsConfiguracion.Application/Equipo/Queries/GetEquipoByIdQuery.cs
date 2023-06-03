using MediatR;
using MsConfiguracion.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.Equipos.Queries
{
    public record GetEquiposByIdQuery([Required] Guid Id) : IRequest<EquiposDto>;
}
