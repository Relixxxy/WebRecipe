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
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDishCategories()
    {
        var items = await _service.GetDishCategories();
        return Ok(new ItemsResponse<CategoryDto>() { Items = items });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsCategories()
    {
        var items = await _service.GetProductCategories();
        return Ok(new ItemsResponse<CategoryDto>() { Items = items });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddProductCategories(CreateCategoryRequest request)
    {
        var result = await _service.AddProductCategory(request.Name, request.BlackIcon, request.WhiteIcon);
        return Ok(new CreateItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddDishCategories(CreateCategoryRequest request)
    {
        var result = await _service.AddDishCategory(request.Name, request.BlackIcon, request.WhiteIcon);
        return Ok(new CreateItemResponse<int?>() { Id = result });
    }
}
