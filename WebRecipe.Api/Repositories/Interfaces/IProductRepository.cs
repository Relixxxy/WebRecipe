using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllProducts();
    Task<int?> AddProduct(string name, string image, string measure);
}
