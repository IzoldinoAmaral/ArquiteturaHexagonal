using hexagonal.Application;
using hexagonal.Domain;

namespace hexagonal.Data;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IQueryable<Product>> GetAllProductsAsync()
    {
        return _repository.GetAll();
    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        await _repository.Add(product).ConfigureAwait(false);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);
        return product;
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    {
        var existingProduct = await _repository.GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _repository.BeginTransactionAsync().ConfigureAwait(false);
            _repository.Update(existingProduct);
            await _repository.CommitTransactionAsync().ConfigureAwait(false);
        }

        return existingProduct;
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var product = await _repository.GetById(id);
        if (product != null)
        {
            await _repository.BeginTransactionAsync().ConfigureAwait(false);
            _repository.Remove(product.Id);
            await _repository.CommitTransactionAsync().ConfigureAwait(false);
        }
    }
}