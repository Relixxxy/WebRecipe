using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Repositories.Interfaces;

public interface IDishRepository
{
    Task<IEnumerable<DishEntity>> GetAllDishes();
    Task<IEnumerable<DishEntity>> GetDishesByCategory(string name);
    Task<int?> AddDish(string name, string recipe, string difficulty, string image, int categoryId, IEnumerable<DishProductEntity> products);
}
