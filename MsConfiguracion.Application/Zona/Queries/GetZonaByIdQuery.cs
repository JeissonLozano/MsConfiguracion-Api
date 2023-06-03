using MediatR;
using MsConfiguracion.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.Zona.Queries
{
    public record GetZonaByIdQuery([Required] Guid Id) : IRequest<ZonaDto>;
}
