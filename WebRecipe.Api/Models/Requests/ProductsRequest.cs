using WebRecipe.Api.Models.Dtos;

namespace WebRecipe.Api.Models.Requests;

public class ProductsRequest
{
    public IEnumerable<LazyProductDto> Products { get; set; } = null!;
}
