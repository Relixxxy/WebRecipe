﻿namespace WebRecipe.Api.Models.Responses;

public class AddItemResponse<T>
{
    public T Id { get; set; } = default!;
}
