using MediatR;
using MsConfiguracion.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MsConfiguracion.Application.TipoEquipo.Queries
{
    public record GetTipoEquipoByIdQuery([Required] Guid Id) : IRequest<TipoEquipoDto>;
}
