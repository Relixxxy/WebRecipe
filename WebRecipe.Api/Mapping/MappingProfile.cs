using AutoMapper;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Models.Dtos;
using WebRecipe.Api.Models.Requests;

namespace WebRecipe.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DishCategoryEntity, CategoryDto>();
        CreateMap<ProductCategoryEntity, CategoryDto>();

        CreateMap<ProductEntity, ProductDto>();
        CreateMap<UserProductEntity, UserProductDto>();

        CreateMap<DishEntity, DishDto>();

        CreateMap<DishProductRequest, DishProductEntity>();
        CreateMap<DishProductDto, DishProductEntity>();
        CreateMap<DishProductEntity, DishProductDto>()
            .ForMember(p => p.Name, src => src.MapFrom(p => p.Product.Name))
            .ForMember(p => p.Image, src => src.MapFrom(p => p.Product.Image))
            .ForMember(p => p.Measure, src => src.MapFrom(p => p.Product.Measure));
    }
}
