using AutoMapper;
using MediatR;
using MsCore.Domain.DTOs;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Equipos.Queries
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
