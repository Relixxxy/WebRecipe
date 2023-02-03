using AutoMapper;
using WebRecipe.Api.Data;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Requests;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Services;

public class DishService
    : BaseDataService<ApplicationDbContext>, IDishService
{
    private readonly IMapper _mapper;
    private readonly IDishRepository _repository;
    public DishService(
        IMapper mapper,
        IDishRepository repository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<int?> AddDish(string name, string recipe, string difficulty, string image, int categoryId, IEnumerable<DishProductRequest> products)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = products.Select(_mapper.Map<DishProductEntity>).ToList();
            return await _repository.AddDish(name, recipe, difficulty, image, categoryId, items);
        });
    }

    public async Task<IEnumerable<DishDto>> GetAllDishes()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _repository.GetAllDishes();
            var dishes = items.Select(_mapper.Map<DishDto>);

            return dishes;
        });
    }
}
