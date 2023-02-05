namespace WebRecipe.Api.Data.Entities;

public class ProductCategoryEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string WhiteIcon { get; set; } = null!;
    public string BlackIcon { get; set; } = null!;
}
