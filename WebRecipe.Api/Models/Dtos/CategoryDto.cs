namespace WebRecipe.Api.Models.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string WhiteIcon { get; set; } = null!;
    public string BlackIcon { get; set; } = null!;
}
