using hexagonal.Data.Mappings;
using hexagonal.Domain;
using Microsoft.EntityFrameworkCore;

namespace hexagonal.Data;

public class HexagonalContext : DbContext
{
    public HexagonalContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}