namespace WebRecipe.Api.Data.Entities;

public class UserProductEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Measure { get; set; } = null!;
    public double Amount { get; set; }
    public int CategoryId { get; set; }
    public ProductCategoryEntity Category { get; set; } = null!;
}
