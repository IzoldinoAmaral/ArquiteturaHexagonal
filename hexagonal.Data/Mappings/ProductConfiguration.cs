using hexagonal.Data.Bases;
using hexagonal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hexagonal.Data.Mappings;

public class ProductConfiguration : BaseMappingConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(b => b.Id).HasColumnName("prod_uuid_Product").IsRequired();
        builder.HasKey(c => c.Id).HasName("pk_prod_Product");
    }
}