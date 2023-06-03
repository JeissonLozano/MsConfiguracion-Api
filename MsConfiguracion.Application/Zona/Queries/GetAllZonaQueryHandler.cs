using AutoMapper;
using MediatR;
using MsConfiguracion.Domain.DTOs;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.Zona.Queries
{
    public class GetAllZonaQueryHandler : IRequestHandler<GetAllZonaQuery, IEnumerable<ZonaDto>>
    {
        private readonly IZonaService ZonaService;
        private readonly IMapper mapper;

        public GetAllZonaQueryHandler(IZonaService ZonaService, IMapper mapper)
        {
            this.ZonaService = ZonaService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ZonaDto>> Handle(GetAllZonaQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return mapper.Map<IEnumerable<ZonaDto>>(await ZonaService.GetAllZonasAsync());
        }
    }

}
