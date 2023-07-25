using Comrade.Persistence.Bases;
using hexagonal.Data.DataAccess;
using hexagonal.Domain.Entities;

namespace hexagonal.Data.Repository;

public class SystemUserRepository : Repository<SystemUser>, ISystemUserRepository
{
    private readonly HexagonalContext _context;

    public SystemUserRepository(HexagonalContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }
}