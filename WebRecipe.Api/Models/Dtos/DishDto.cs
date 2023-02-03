using WebRecipe.Api.Data.Entities;

namespace WebRecipe.Api.Models.Dtos;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Recipe { get; set; } = null!;
    public string Difficulty { get; set; } = null!;
    public string Image { get; set; } = null!;
    public CategoryDto Category { get; set; } = null!;
    public IEnumerable<DishProductDto> Products { get; set; } = null!;
}
