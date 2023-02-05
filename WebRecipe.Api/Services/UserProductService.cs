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

    public async Task<IEnumerable<UserProductDto>> GetMissingProducts(IEnumerable<LazyProductDto> dishProducts)
    {
        var result = new List<UserProductDto>();

        var userProducts = await _userProductRepository.GetAllProducts();

        foreach (var dp in dishProducts)
        {
            bool isFound = false;

            foreach (var up in userProducts)
            {
                if (dp.Name.Equals(up.Name))
                {
                    var amount = up.Amount - dp.Amount;

                    if (amount < 0)
                    {
                        result.Add(new UserProductDto { Name = dp.Name, Amount = Math.Abs(amount) });
                    }

                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                result.Add(new UserProductDto { Name = dp.Name, Amount = dp.Amount });
            }
        }

        return result;
    }
}
