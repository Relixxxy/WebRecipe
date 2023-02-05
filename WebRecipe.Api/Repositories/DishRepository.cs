using Microsoft.EntityFrameworkCore;
using WebRecipe.Api.Data;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Repositories;

public class DishRepository : IDishRepository
{
    private readonly ApplicationDbContext _context;

    public DishRepository(IDbContextWrapper<ApplicationDbContext> dbWrapper)
    {
        _context = dbWrapper.DbContext;
    }

    public async Task<int?> AddDish(string name, string recipe, string difficulty, string image, int categoryId, IEnumerable<DishProductEntity> products)
    {
        var item = await _context.Dishes.AddAsync(new DishEntity { Name = name, Recipe = recipe, Difficulty = difficulty, Image = image, CategoryId = categoryId, Products = products });
        await _context.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<IEnumerable<DishEntity>> GetAllDishes()
    {
        return await _context.Dishes.Include(d => d.Category).Include(d => d.Products).ThenInclude(p => p.Product).ToListAsync();
    }

    public async Task<IEnumerable<DishEntity>> GetDishesByCategory(string name)
    {
        return await _context.Dishes.Where(d => d.Category.Name.ToLower() == name.ToLower()).Include(d => d.Category).Include(d => d.Products).ThenInclude(p => p.Product).ToListAsync();
    }
}
