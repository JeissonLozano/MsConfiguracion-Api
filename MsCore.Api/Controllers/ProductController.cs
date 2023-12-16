using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsCore.Application.Product.Commands;
using MsCore.Application.Product.Queries;
using MsCore.Domain.DTOs;

namespace MsCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Obtener todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await mediator.Send(new GetAllProductsQuery());
        }


        /// <summary>
        /// Buscar producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ProductDto> GetAsync(Guid id)
        {
            return await mediator.Send(new GetProductByIdQuery(id));
        }

        /// <summary>
        /// Registrar producto
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task PostAsync(CreateProductCommand Producto)
        {
            await mediator.Send(Producto);
        }

        /// <summary>
        /// Actualizar producto
        /// </summary>
        /// <param name="Producto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutAsync(UpdateProductAsyncCommand Producto, Guid id)
        {
            await mediator.Send(new UpdateProductAsyncCommand(id, 
                Producto.Name, Producto.Description, Producto.Price, Producto.Stock));
        }

        /// <summary>
        /// Eliminar producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await mediator.Send(new DeleteProductAsyncCommand(id));
        }
    }
}
