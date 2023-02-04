namespace WebRecipe.Api.Models.Requests;

public class CreateCategoryRequest
{
    public string Name { get; set; } = null!;
    public string WhiteIcon { get; set; } = null!;
    public string BlackIcon { get; set; } = null!;
}
