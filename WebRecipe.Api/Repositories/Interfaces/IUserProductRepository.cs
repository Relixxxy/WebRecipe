using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Repositories.Interfaces;

public interface IUserProductRepository
{
    Task<IEnumerable<UserProductEntity>> GetAllProducts();
    Task<int?> AddProduct(string name, string image, string measure, double amount, int categoryId);
}
