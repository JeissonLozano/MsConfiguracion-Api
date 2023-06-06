using MediatR;
using MsCore.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MsCore.Application.TipoEquipo.Queries
{
    public record GetTipoEquipoByIdQuery([Required] Guid Id) : IRequest<TipoEquipoDto>;
}
