using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Data.EntityConfigurations;

public class ProductCategoryEntityConfiguration
    : IEntityTypeConfiguration<ProductCategoryEntity>
{
    public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        builder.ToTable("ProductCategory");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("product_category_hilo")
            .IsRequired();

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.BlackIcon)
            .IsRequired();

        builder.Property(ci => ci.WhiteIcon)
            .IsRequired();
    }
}
