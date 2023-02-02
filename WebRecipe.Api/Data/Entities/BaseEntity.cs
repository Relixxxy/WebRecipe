using WebRecipe.Api.Data.Entities.Interfaces;

namespace WebRecipe.Api.Data.Entities;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
}
