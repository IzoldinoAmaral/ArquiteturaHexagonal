using hexagonal.Domain;

namespace hexagonal.Application;

public interface IProductService
{
    Task<IQueryable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductAsync(Guid id);
    Task<Product> AddProductAsync(Product product);
    Task<Product?> UpdateProductAsync(Product product);
    Task DeleteProductAsync(Guid id);
}