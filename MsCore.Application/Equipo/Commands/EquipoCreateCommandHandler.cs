using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Equipos.Commands
{
    public class EquiposCreateCommandHandler : AsyncRequestHandler<EquiposCreateCommand>
    {
        private readonly IEquiposService EquiposService;

        public EquiposCreateCommandHandler(IEquiposService EquiposService)
        {
            this.EquiposService = EquiposService;
        }

        protected override async Task Handle(EquiposCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await EquiposService.RegisterEquiposAsync(new Domain.Entities.Equipo
            {
                Id = Guid.NewGuid(), 
                Codigo = request.Codigo, 
                Estado = request.Estado, 
                Observaciones = request.Observaciones, 
                IdTipoEquipo = request.IdTipoEquipo
            });
        }
    }
}
