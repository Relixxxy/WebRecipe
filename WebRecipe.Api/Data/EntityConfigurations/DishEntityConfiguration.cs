using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Data.EntityConfigurations;

public class DishEntityConfiguration
    : IEntityTypeConfiguration<DishEntity>
{
    public void Configure(EntityTypeBuilder<DishEntity> builder)
    {
        builder.ToTable("Dish");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("dish_hilo")
            .IsRequired();

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Recipe)
            .IsRequired();

        builder.Property(ci => ci.Group)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Difficulty)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Image)
           .IsRequired();
    }
}
