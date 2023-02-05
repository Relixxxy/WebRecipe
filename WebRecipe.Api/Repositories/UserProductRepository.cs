using Microsoft.EntityFrameworkCore;
using WebRecipe.Api.Data;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;
using WebRecipe.Api.Tools;

namespace WebRecipe.Api.Repositories
{
    public class UserProductRepository : IUserProductRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProductRepository(IDbContextWrapper<ApplicationDbContext> dbWrapper)
        {
            _context = dbWrapper.DbContext;
        }

        public async Task<int?> AddProduct(string name, string image, string measure, double amount, int categoryId)
        {
            var prod = await _context.UserProducts.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
            int id;

            if (prod is null)
            {
                var item = await _context.UserProducts.AddAsync(new UserProductEntity { Name = name, Image = image, Measure = measure, Amount = amount, CategoryId = categoryId });
                id = item.Entity.Id;
            }
            else
            {
                prod.Amount += amount;
                id = prod.Id;
            }

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<IEnumerable<UserProductEntity>> GetAllProducts()
        {
            return await _context.UserProducts.Include(i => i.Category).ToListAsync();
        }
    }
}
