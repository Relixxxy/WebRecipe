using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Requests;
using WebRecipe.Api.Models.Responses;
using WebRecipe.Api.Services.Interfaces;
using WebRecipe.Infrastructure;

namespace WebRecipe.Api.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            var result = await _productService.AddProduct(request.Name, request.Image, request.Measure);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemsResponse<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }
    }
}
