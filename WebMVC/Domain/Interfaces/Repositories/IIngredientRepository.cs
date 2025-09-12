using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IIngredientRepository : IEntityRepository<Ingredient>
    {
        Task<PagedResult<Ingredient>> GetAllAsync(IngredientQuery query);
    }
}
