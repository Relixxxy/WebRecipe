using System.ComponentModel;

namespace WebRecipe.Api.Models.Dtos;

public class UserProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Measure { get; set; } = null!;
    public double Amount { get; set; }
    public CategoryDto Category { get; set; } = null!;
}
