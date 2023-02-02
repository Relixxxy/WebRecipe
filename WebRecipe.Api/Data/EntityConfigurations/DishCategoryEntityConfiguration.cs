using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Data.EntityConfigurations;

public class DishCategoryEntityConfiguration
    : IEntityTypeConfiguration<DishCategoryEntity>
{
    public void Configure(EntityTypeBuilder<DishCategoryEntity> builder)
    {
        builder.ToTable("DishCategory");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("dish_category_hilo")
            .IsRequired();

        builder.Property(ci => ci.Name)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(ci => ci.Image)
        .IsRequired();
    }
}
