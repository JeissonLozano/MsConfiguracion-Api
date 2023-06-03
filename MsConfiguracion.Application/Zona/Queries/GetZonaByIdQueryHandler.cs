using AutoMapper;
using MediatR;
using MsConfiguracion.Domain.DTOs;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.Zona.Queries
{
    public class GetZonaByIdQueryHandler : IRequestHandler<GetZonaByIdQuery, ZonaDto>
    {
        private readonly IZonaService ZonaService;
        private readonly IMapper mapper;

        public GetZonaByIdQueryHandler(IZonaService ZonaService, IMapper mapper)
        {
            this.ZonaService = ZonaService;
            this.mapper = mapper;
        }

        public async Task<ZonaDto> Handle(GetZonaByIdQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");
            return mapper.Map<ZonaDto>(await ZonaService.GetZonaAsync(request.Id));
        }
    }
}
