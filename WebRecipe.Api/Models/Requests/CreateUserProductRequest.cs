namespace WebRecipe.Api.Models.Requests;

public class CreateUserProductRequest
{
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Measure { get; set; } = null!;
    public double Amount { get; set; }
    public int CategoryId { get; set; }
}
