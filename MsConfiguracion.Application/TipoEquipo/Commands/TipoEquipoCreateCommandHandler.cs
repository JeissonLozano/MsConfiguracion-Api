using MediatR;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.TipoEquipo.Commands
{
    public class TipoEquipoCreateCommandHandler : AsyncRequestHandler<TipoEquipoCreateCommand>
    {
        private readonly ITipoEquipoService TipoEquipoService;

        public TipoEquipoCreateCommandHandler(ITipoEquipoService TipoEquipoService)
        {
            this.TipoEquipoService = TipoEquipoService;
        }

        protected override async Task Handle(TipoEquipoCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await TipoEquipoService.RegisterTipoEquipoAsync(new Domain.Entities.TipoEquipo
            {
                Id = Guid.NewGuid(), 
                NombreTipoEquipo = request.NombreTipoEquipo, 
                Descripcion = request.Descripcion
            });
        }
    }
}
