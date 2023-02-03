using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Data.EntityConfigurations;

public class ProductEntityConfiguration
    : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("product_hilo")
            .IsRequired();

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Measure)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Image)
           .IsRequired();
    }
}
