using MediatR;
using MsCore.Domain.Interfaces;

namespace MsCore.Application.Product.Commands
{
    public class CreateProductCommandHandler : AsyncRequestHandler<CreateProductCommand>
    {
        private readonly IProductService ProductService;

        public CreateProductCommandHandler(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        protected override async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");

            await ProductService.RegisterProductAsync(new Domain.Entities.Product
            {
                Id = Guid.NewGuid(), 
                Name = request.Name, 
                Description = request.Description, 
                Price = request.Price, 
                Stock = request.Stock
            });
        }
    }
}
