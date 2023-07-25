using Comrade.Persistence.Bases;
using hexagonal.Data.DataAccess;
using hexagonal.Domain.Entities;

namespace hexagonal.Data.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly HexagonalContext _context;

    public CategoryRepository(HexagonalContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }
}