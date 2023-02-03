﻿using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Requests;

namespace WebRecipe.Api.Services.Interfaces;

public interface IDishService
{
    Task<IEnumerable<DishDto>> GetAllDishes();
    Task<int?> AddDish(string name, string recipe, string difficulty, string image, int categoryId, IEnumerable<DishProductRequest> products);
}