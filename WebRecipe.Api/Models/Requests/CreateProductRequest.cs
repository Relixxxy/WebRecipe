namespace WebRecipe.Api.Models.Requests;

public class CreateProductRequest
{
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Measure { get; set; } = null!;
}
