using MediatR;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Application.Zona.Commands
{
    public class ZonaDeleteAsyncCommandHandler : AsyncRequestHandler<ZonaDeleteAsyncCommand>
    {
        private readonly IZonaService ZonaService;

        public ZonaDeleteAsyncCommandHandler(IZonaService ZonaService)
        {
            this.ZonaService = ZonaService;
        }
        protected override async Task Handle(ZonaDeleteAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await ZonaService.DeleteZonaAsync(request.Id);

        }
    }
}
