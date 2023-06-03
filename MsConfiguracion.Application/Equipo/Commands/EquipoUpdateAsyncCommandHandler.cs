using MediatR;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.Equipos.Commands
{
    public class EquiposUpdateAsyncCommandHandler : AsyncRequestHandler<EquiposUpdateAsyncCommand>
    {
        private readonly IEquiposService EquiposService;

        public EquiposUpdateAsyncCommandHandler(IEquiposService EquiposService)
        {
            this.EquiposService = EquiposService;
        }

        protected override async Task Handle(EquiposUpdateAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await EquiposService.UpdateEquiposAsync(new Domain.Entities.Equipo
            {
                Id = request.Id,
                Codigo = request.Codigo,
                Estado = request.Estado,
                Observaciones = request.Observaciones,
                IdTipoEquipo = request.IdTipoEquipo
            });
        }
    }
}
