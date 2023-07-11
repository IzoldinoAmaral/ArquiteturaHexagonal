using hexagonal.Data.Bases;
using hexagonal.Domain;

namespace hexagonal.Data;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly HexagonalContext _context;

    public ProductRepository(HexagonalContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }
}