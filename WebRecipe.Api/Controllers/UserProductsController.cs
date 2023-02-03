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
public class UserProductsController : ControllerBase
{
    private readonly IUserProductService _productService;

    public UserProductsController(IUserProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsResponse<UserProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _productService.GetAllProducts();
        return Ok(new ItemsResponse<UserProductDto>() { Items = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateUserProductRequest request)
    {
        var result = await _productService.AddProduct(request.Name, request.Image, request.Measure, request.Amount, request.CategoryId);
        return Ok(new CreateItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsResponse<UserProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMissingProducts(ProductsRequest request)
    {
        var result = await _productService.GetMissingProducts(request.Products);
        return Ok(new ItemsResponse<UserProductDto> { Items = result });
    }
}
