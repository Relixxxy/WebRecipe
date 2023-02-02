namespace WebRecipe.Api.Data.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Group { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Measure { get; set; } = null!;
    public IEnumerable<DishProductEntity> Dishes { get; set; } = null!;
}