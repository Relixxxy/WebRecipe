using AutoMapper;
using WebRecipe.Api.Data;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Repositories.Interfaces;
using WebRecipe.Api.Services.Interfaces;

namespace WebRecipe.Api.Services;

public class CategoryService
    : BaseDataService<ApplicationDbContext>, ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    public CategoryService(
        IMapper mapper,
        ICategoryRepository repository,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<int?> AddDishCategory(string name, string image)
    {
        return ExecuteSafeAsync(() => _repository.AddDishCategory(name, image));
    }

    public Task<int?> AddProductCategory(string name, string image)
    {
        return ExecuteSafeAsync(() => _repository.AddProductCategory(name, image));
    }

    public async Task<IEnumerable<CategoryDto>> GetDishCategories()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _repository.GetDishCategories();
            var categories = items.Select(_mapper.Map<CategoryDto>);

            return categories;
        });
    }

    public async Task<IEnumerable<CategoryDto>> GetProductCategories()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _repository.GetProductCategories();
            var categories = items.Select(_mapper.Map<CategoryDto>);

            return categories;
        });
    }
}
