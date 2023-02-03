using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Responses;

namespace WebRecipe.Api.Services.Interfaces;

public interface IUserProductService
{
    Task<IEnumerable<UserProductDto>> GetAllProducts();
    Task<int?> AddProduct(string name, string image, string measure, double amount, int categoryId);
}
