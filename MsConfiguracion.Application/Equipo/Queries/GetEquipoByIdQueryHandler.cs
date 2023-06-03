using AutoMapper;
using MediatR;
using MsConfiguracion.Domain.DTOs;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.Equipos.Queries
{
    public class GetEquiposByIdQueryHandler : IRequestHandler<GetEquiposByIdQuery, EquiposDto>
    {
        private readonly IEquiposService EquiposService;
        private readonly IMapper mapper;

        public GetEquiposByIdQueryHandler(IEquiposService EquiposService, IMapper mapper)
        {
            this.EquiposService = EquiposService;
            this.mapper = mapper;
        }

        public async Task<EquiposDto> Handle(GetEquiposByIdQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return mapper.Map<EquiposDto>(await EquiposService.GetEquiposAsync(request.Id));
        }
    }
}
