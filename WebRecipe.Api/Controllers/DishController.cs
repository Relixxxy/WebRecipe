using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Requests;
using WebRecipe.Api.Models.Responses;
using WebRecipe.Api.Services.Interfaces;
using WebRecipe.Infrastructure;

namespace WebRecipe.Api.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class DishController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsResponse<DishDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDishes()
    {
        var result = await _dishService.GetAllDishes();
        return Ok(new ItemsResponse<DishDto>() { Items = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateDishRequest request)
    {
        var result = await _dishService.AddDish(request.Name, request.Recipe, request.Difficulty, request.Image, request.CategoryId, request.Products);
        return Ok(new CreateItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsResponse<DishDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDishesByProducts()
    {
        var result = await _dishService.GetDishesByProducts();
        return Ok(new ItemsResponse<DishDto>() { Items = result });
    }
}
