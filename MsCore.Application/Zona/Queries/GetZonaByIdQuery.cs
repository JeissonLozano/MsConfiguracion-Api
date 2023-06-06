using MediatR;
using MsCore.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.Zona.Queries
{
    public record GetZonaByIdQuery([Required] Guid Id) : IRequest<ZonaDto>;
}
