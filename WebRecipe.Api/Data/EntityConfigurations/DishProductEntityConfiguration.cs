using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Data.EntityConfigurations;

public class DishProductEntityConfiguration
    : IEntityTypeConfiguration<DishProductEntity>
{
    public void Configure(EntityTypeBuilder<DishProductEntity> builder)
    {
        builder.ToTable("DishProduct");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("dish_product_hilo")
            .IsRequired();

        builder.Property(ci => ci.Amount)
           .IsRequired();

        builder.HasOne(ci => ci.Product)
            .WithMany(ci => ci.Dishes)
            .HasForeignKey(ci => ci.ProductId);

        builder.HasOne(ci => ci.Dish)
            .WithMany(ci => ci.Products)
            .HasForeignKey(ci => ci.DishId);
    }
}
