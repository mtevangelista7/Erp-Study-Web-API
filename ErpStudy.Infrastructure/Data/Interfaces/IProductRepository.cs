using ErpStudy.Domain.Entities;

namespace ErpStudy.Infrastructure.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<List<Product>> GetAllProductsAsync();
        Task<bool> DeleteProductAsync(Guid id);
    }
}