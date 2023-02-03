using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Responses;

namespace WebRecipe.Api.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProducts();
    Task<int?> AddProduct(string name, string image, string measure);
}
