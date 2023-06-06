using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Zona.Commands
{
    public class ZonaCreateCommandHandler : AsyncRequestHandler<ZonaCreateCommand>
    {
        private readonly IZonaService ZonaService;

        public ZonaCreateCommandHandler(IZonaService ZonaService)
        {
            this.ZonaService = ZonaService;
        }

        protected override async Task Handle(ZonaCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await ZonaService.RegisterZonaAsync(new Domain.Entities.Zona 
            { 
                Id =Guid.NewGuid(), 
                Nombre = request.Nombre, 
                Descripcion = request.Descripcion, 
                Estado = request.Estado
            });
        }
    }
}
