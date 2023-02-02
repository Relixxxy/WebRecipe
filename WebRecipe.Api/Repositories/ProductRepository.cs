using Microsoft.EntityFrameworkCore;
using WebRecipe.Api.Data;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(IDbContextWrapper<ApplicationDbContext> dbWrapper)
    {
        _context = dbWrapper!.DbContext;
    }

    public async Task<int?> AddProduct(string name, string image, string measure)
    {
        var item = await _context.Products.AddAsync(new ProductEntity { Name = name, Image = image, Measure = measure });
        await _context.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }
}
