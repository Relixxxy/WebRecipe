using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Data.EntityConfigurations;

public class UserProductEntityConfiguration
    : IEntityTypeConfiguration<UserProductEntity>
{
    public void Configure(EntityTypeBuilder<UserProductEntity> builder)
    {
        builder.ToTable("UserProduct");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("user_product_hilo")
            .IsRequired();

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Group)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Measure)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Image)
           .IsRequired();

        builder.Property(ci => ci.Amount)
           .IsRequired();
    }
}
