using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Zona.Commands
{
    public class ZonaUpdateAsyncCommandHandler : AsyncRequestHandler<ZonaUpdateAsyncCommand>
    {
        private readonly IZonaService ZonaService;

        public ZonaUpdateAsyncCommandHandler(IZonaService ZonaService)
        {
            this.ZonaService = ZonaService;
        }

        protected override async Task Handle(ZonaUpdateAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await ZonaService.UpdateZonaAsync(new Domain.Entities.Zona
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Estado = request.Estado
            });
        }
    }

}
