using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IRecipeRepository : IEntityRepository<Recipe>
    {
        Task<PagedResult<Recipe>> GetAllAsync(RecipeQuery query);
    }
}
