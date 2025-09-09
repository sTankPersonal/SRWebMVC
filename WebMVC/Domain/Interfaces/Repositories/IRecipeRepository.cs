using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IRecipeRepository : IEntityRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetAllAsync(RecipeQuery query);
    }
}
