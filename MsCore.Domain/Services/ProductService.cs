using MsCore.Domain.Entities;
using MsCore.Domain.Interfaces;

namespace MsCore.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> genericRepository;

        public ProductService(IGenericRepository<Product> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Product>> GetAllEquipossAsync()
        {
            return await genericRepository.GetAsync();
        }

        public async Task<Product> GetProductsAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await genericRepository.GetByIdAsync(id);
        }

        public async Task<Product> RegisterProductAsync(Product Equipos)
        {
            if (Equipos == null)
            {
                throw new ArgumentNullException(nameof(Equipos));
            }

            return await genericRepository.AddAsync(Equipos);
        }

        public async Task UpdateProductAsync(Product Equipos)
        {
            if (Equipos == null)
            {
                throw new ArgumentNullException(nameof(Equipos));
            }
            await genericRepository.UpdateAsync(Equipos);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var Equipos = await genericRepository.GetByIdAsync(id);

            await genericRepository.DeleteAsync(Equipos);
        }
    }
}
