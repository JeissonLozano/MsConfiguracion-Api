using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Product.Commands
{
    public class UpdateProductAsyncCommandHandler : AsyncRequestHandler<UpdateProductAsyncCommand>
    {
        private readonly IProductService ProductService;

        public UpdateProductAsyncCommandHandler(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        protected override async Task Handle(UpdateProductAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await ProductService.UpdateProductAsync(new Domain.Entities.Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            });
        }
    }
}
