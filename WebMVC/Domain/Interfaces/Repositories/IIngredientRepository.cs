using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IIngredientRepository : IEntityRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> GetAllAsync(IngredientQuery query);
    }
}
