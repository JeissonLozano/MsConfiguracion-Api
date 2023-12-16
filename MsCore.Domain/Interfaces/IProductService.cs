using MsCore.Domain.Entities;

namespace MsCore.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllEquipossAsync();
        Task<Product> GetProductsAsync(Guid id);
        Task<Product> RegisterProductAsync(Product Equipos);
        Task UpdateProductAsync(Product Equipos);
        Task DeleteProductAsync(Guid id);
    }
}
