using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Product.Commands
{
    public class DeleteProductAsyncCommandHandler : AsyncRequestHandler<DeleteProductAsyncCommand>
    {
        private readonly IProductService ProductService;

        public DeleteProductAsyncCommandHandler(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        protected override async Task Handle(DeleteProductAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await ProductService.DeleteProductAsync(request.Id);
        }
    }
}
