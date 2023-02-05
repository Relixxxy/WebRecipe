using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<DishCategoryEntity>> GetDishCategories();
    Task<int?> AddDishCategory(string name, string blackIcon, string whiteIcon);
    Task<IEnumerable<ProductCategoryEntity>> GetProductCategories();
    Task<int?> AddProductCategory(string name, string blackIcon, string whiteIcon);
}
