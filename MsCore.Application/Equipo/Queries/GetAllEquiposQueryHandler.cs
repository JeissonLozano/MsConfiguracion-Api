using AutoMapper;
using MediatR;
using MsCore.Domain.DTOs;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Equipos.Queries
{
    public class GetAllEquipossQueryHandler : IRequestHandler<GetAllEquipossQuery, IEnumerable<EquiposDto>>
    {
        private readonly IEquiposService EquiposService;
        private readonly IMapper mapper;

        public GetAllEquipossQueryHandler(IEquiposService EquiposService, IMapper mapper)
        {
            this.EquiposService = EquiposService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EquiposDto>> Handle(GetAllEquipossQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return mapper.Map<IEnumerable<EquiposDto>>(await EquiposService.GetAllEquipossAsync());
        }
    }
}
