using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces
{
    public interface IRecipeRepository : IEntityRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetAllAsync(RecipeQuery query);
    }
}
