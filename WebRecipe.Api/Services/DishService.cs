using AutoMapper;
using WebRecipe.Api.Data;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Requests;
using WebRecipe.Api.Repositories;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Services;

public class DishService
    : BaseDataService<ApplicationDbContext>, IDishService
{
    private readonly IMapper _mapper;
    private readonly IDishRepository _dishRepository;
    private readonly IUserProductRepository _productRepository;
    public DishService(
        IMapper mapper,
        IDishRepository dishRepository,
        IUserProductRepository productsRepository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _dishRepository = dishRepository;
        _productRepository = productsRepository;
    }

    public async Task<int?> AddDish(string name, string recipe, string difficulty, string image, int categoryId, IEnumerable<DishProductRequest> products)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = products.Select(_mapper.Map<DishProductEntity>).ToList();
            return await _dishRepository.AddDish(name, recipe, difficulty, image, categoryId, items);
        });
    }

    public async Task<IEnumerable<DishDto>> GetAllDishes()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _dishRepository.GetAllDishes();
            var dishes = items.Select(_mapper.Map<DishDto>);

            return dishes;
        });
    }

    public async Task<IEnumerable<DishDto>> GetDishesByProducts()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var dishesEntities = await _dishRepository.GetAllDishes();
            var productsEntities = await _productRepository.GetAllProducts();

            var dishes = FindDishes(dishesEntities, productsEntities);

            return dishes;
        });
    }

    public async Task<IEnumerable<DishDto>> GetDishesByCategory(string name)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _dishRepository.GetDishesByCategory(name);
            var dishes = items.Select(_mapper.Map<DishDto>);

            return dishes;
        });
    }

    private IEnumerable<DishDto> FindDishes(IEnumerable<DishEntity> dishesEntities, IEnumerable<UserProductEntity> productsEntities)
    {
        var dishes = new List<DishDto>();

        foreach (var de in dishesEntities)
        {
            if (de.Products.Select(p => p.Product.Name).Except(productsEntities.Select(pe => pe.Name)).Count() == 0)
            {
                dishes.Add(_mapper.Map<DishDto>(de));
            }
        }

        return dishes;
    }
}
