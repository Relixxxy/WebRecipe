#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Data.EntityConfigurations;

namespace WebRecipe.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<DishEntity> Dishes { get; set; }
    public DbSet<UserProductEntity> UserProducts { get; set; }
    public DbSet<DishCategoryEntity> DishesCategories { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProductEntityConfiguration());
        builder.ApplyConfiguration(new UserProductEntityConfiguration());
        builder.ApplyConfiguration(new DishEntityConfiguration());
        builder.ApplyConfiguration(new DishProductEntityConfiguration());
        builder.ApplyConfiguration(new DishCategoryEntityConfiguration());
        builder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
    }
}
