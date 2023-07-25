using Comrade.Persistence.Bases;
using hexagonal.Data.DataAccess;
using hexagonal.Domain.Entities;

namespace hexagonal.Data.Repository;

public class BookRepository : Repository<Book>, IBookRepository
{
    private readonly HexagonalContext _context;

    public BookRepository(HexagonalContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }
}