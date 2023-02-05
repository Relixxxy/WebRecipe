using WebRecipe.Api.Models.Dtos;

namespace WebRecipe.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetDishCategories();
    Task<int?> AddDishCategory(string name, string blackIcon, string whiteIcon);
    Task<IEnumerable<CategoryDto>> GetProductCategories();
    Task<int?> AddProductCategory(string name, string blackIcon, string whiteIcon);
}
