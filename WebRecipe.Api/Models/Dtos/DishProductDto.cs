namespace WebRecipe.Api.Models.Dtos;

public class DishProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Measure { get; set; } = null!;
    public double Amount { get; set; }
    public int ProductId { get; set; }
    public int DishId { get; set; }
}
