namespace WebRecipe.Api.Data.Entities;

public class DishProductEntity : BaseEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int DishId { get; set; }
    public DishEntity Dish { get; set; } = null!;
    public double Amount { get; set; }
}
