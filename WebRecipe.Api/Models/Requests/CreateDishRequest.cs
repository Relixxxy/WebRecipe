namespace WebRecipe.Api.Models.Requests;

public class CreateDishRequest
{
    public string Name { get; set; } = null!;
    public string Recipe { get; set; } = null!;
    public string Difficulty { get; set; } = null!;
    public string Image { get; set; } = null!;
    public int CategoryId { get; set; }
    public IEnumerable<DishProductRequest> Products { get; set; } = null!;
}
