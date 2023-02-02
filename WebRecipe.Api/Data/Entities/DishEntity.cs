namespace WebRecipe.Api.Data.Entities;

public class DishEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Recipe { get; set; } = null!;
    public string Difficulty { get; set; } = null!;
    public string Image { get; set; } = null!;
    public int CategoryId { get; set; }
    public DishCategoryEntity Category { get; set; } = null!;
    public IEnumerable<DishProductEntity> Products { get; set; } = null!;
}
