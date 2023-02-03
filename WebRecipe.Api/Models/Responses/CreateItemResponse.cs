namespace WebRecipe.Api.Models.Responses;

public class CreateItemResponse<T>
{
    public T Id { get; set; } = default!;
}
