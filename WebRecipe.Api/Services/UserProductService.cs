using AutoMapper;
using WebRecipe.Api.Data;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Services;

public class UserProductService
    : BaseDataService<ApplicationDbContext>, IUserProductService
{
    private readonly IMapper _mapper;
    private readonly IUserProductRepository _userProductRepository;
    public UserProductService(
        IMapper mapper,
        IUserProductRepository userProductRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _userProductRepository = userProductRepository;
    }

    public Task<int?> AddProduct(string name, string image, string measure, double amount, int categoryId)
    {
        return ExecuteSafeAsync(() => _userProductRepository.AddProduct(name, image, measure, amount, categoryId));
    }

    public async Task<IEnumerable<UserProductDto>> GetAllProducts()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _userProductRepository.GetAllProducts();
            var products = items.Select(_mapper.Map<UserProductDto>);
            return products;
        });
    }
}
