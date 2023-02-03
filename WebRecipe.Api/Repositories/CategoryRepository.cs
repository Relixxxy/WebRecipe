using Microsoft.EntityFrameworkCore;
using WebRecipe.Api.Data;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(IDbContextWrapper<ApplicationDbContext> dbWrapper)
    {
        _context = dbWrapper.DbContext;
    }

    public async Task<int?> AddDishCategory(string name, string image)
    {
        var item = await _context.DishCategories.AddAsync(new DishCategoryEntity { Name = name, Image = image });
        await _context.SaveChangesAsync();
        return item.Entity.Id;
    }

    public async Task<int?> AddProductCategory(string name, string image)
    {
        var item = await _context.ProductCategories.AddAsync(new ProductCategoryEntity { Name = name, Image = image });
        await _context.SaveChangesAsync();
        return item.Entity.Id;
    }

    public async Task<IEnumerable<DishCategoryEntity>> GetDishCategories()
    {
        return await _context.DishCategories.ToListAsync();
    }

    public async Task<IEnumerable<ProductCategoryEntity>> GetProductCategories()
    {
        return await _context.ProductCategories.ToListAsync();
    }
}
