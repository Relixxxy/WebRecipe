using AutoMapper;
using WebRecipe.Api.Data.Entities;
using WebRecipe.Api.Models.Dtos;

namespace WebRecipe.Api.Mapping;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<ProductEntity, ProductDto>();
	}
}
