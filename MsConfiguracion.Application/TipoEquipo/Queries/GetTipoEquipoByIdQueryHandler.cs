﻿using AutoMapper;
using MediatR;
using MsConfiguracion.Domain.DTOs;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.TipoEquipo.Queries
{
    public class GetTipoEquipoByIdQueryHandler : IRequestHandler<GetTipoEquipoByIdQuery, TipoEquipoDto>
    {
        private readonly ITipoEquipoService TipoEquipoService;
        private readonly IMapper mapper;

        public GetTipoEquipoByIdQueryHandler(ITipoEquipoService TipoEquipoService, IMapper mapper)
        {
            this.TipoEquipoService = TipoEquipoService;
            this.mapper = mapper;
        }

        public async Task<TipoEquipoDto> Handle(GetTipoEquipoByIdQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            return mapper.Map<TipoEquipoDto>(await TipoEquipoService.GetTipoEquipoAsync(request.Id));
        }
    }
}
