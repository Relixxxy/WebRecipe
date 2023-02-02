using AutoMapper;
using WebRecipe.Api.Data;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Responses;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Services;

public class ProductService
    : BaseDataService<ApplicationDbContext>, IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(
        IMapper mapper,
        IProductRepository productRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public Task<int?> AddProduct(string name, string image, string measure)
    {
        return ExecuteSafeAsync(() => _productRepository.AddProduct(name, image, measure));
    }

    public async Task<ItemsResponse<ProductDto>> GetAllProducts()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var products = await _productRepository.GetAllProducts();
            var productsResponse = new ItemsResponse<ProductDto>()
            {
                Items = products.Select(_mapper.Map<ProductDto>),
            };

            return productsResponse;
        });
    }
}
