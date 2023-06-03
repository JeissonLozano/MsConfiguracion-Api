using AutoMapper;
using MediatR;
using MsConfiguracion.Domain.DTOs;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.TipoEquipo.Queries
{
    public class GetAllTipoEquiposQueryHandler : IRequestHandler<GetAllTipoEquiposQuery, IEnumerable<TipoEquipoDto>>
    {
        private readonly ITipoEquipoService TipoEquipoService;
        private readonly IMapper mapper;

        public GetAllTipoEquiposQueryHandler(ITipoEquipoService TipoEquipoService, IMapper mapper)
        {
            this.TipoEquipoService = TipoEquipoService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TipoEquipoDto>> Handle(GetAllTipoEquiposQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return mapper.Map<IEnumerable<TipoEquipoDto>>(await TipoEquipoService.GetAllTipoEquiposAsync());
        }
    }
}
