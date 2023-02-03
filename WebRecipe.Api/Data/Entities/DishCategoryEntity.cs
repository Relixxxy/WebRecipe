namespace WebRecipe.Api.Data.Entities;

public class DishCategoryEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
}
