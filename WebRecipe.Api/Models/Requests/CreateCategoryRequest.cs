namespace WebRecipe.Api.Models.Requests;

public class CreateCategoryRequest
{
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
}
