using MediatR;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.TipoEquipo.Commands
{
    public class TipoEquipoUpdateAsyncCommandHandler : AsyncRequestHandler<TipoEquipoUpdateAsyncCommand>
    {
        private readonly ITipoEquipoService TipoEquipoService;

        public TipoEquipoUpdateAsyncCommandHandler(ITipoEquipoService TipoEquipoService)
        {
            this.TipoEquipoService = TipoEquipoService;
        }

        protected override async Task Handle(TipoEquipoUpdateAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await TipoEquipoService.UpdateTipoEquipoAsync(new Domain.Entities.TipoEquipo
            {
                Id = request.Id,
                NombreTipoEquipo = request.NombreTipoEquipo,
                Descripcion = request.Descripcion
            });
        }
    }
}
