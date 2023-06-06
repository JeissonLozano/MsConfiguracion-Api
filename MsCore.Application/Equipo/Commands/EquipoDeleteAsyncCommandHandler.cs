using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Equipos.Commands
{
    public class EquiposDeleteAsyncCommandHandler : AsyncRequestHandler<EquiposDeleteAsyncCommand>
    {
        private readonly IEquiposService EquiposService;

        public EquiposDeleteAsyncCommandHandler(IEquiposService EquiposService)
        {
            this.EquiposService = EquiposService;
        }

        protected override async Task Handle(EquiposDeleteAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await EquiposService.DeleteEquiposAsync(request.Id);
        }
    }
}
