using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.TipoEquipo.Commands
{
    public class TipoEquipoDeleteAsyncCommandHandler : AsyncRequestHandler<TipoEquipoDeleteAsyncCommand>
    {
        private readonly ITipoEquipoService TipoEquipoService;

        public TipoEquipoDeleteAsyncCommandHandler(ITipoEquipoService TipoEquipoService)
        {
            this.TipoEquipoService = TipoEquipoService;
        }

        protected override async Task Handle(TipoEquipoDeleteAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await TipoEquipoService.DeleteTipoEquipoAsync(request.Id);
        }
    }
}
