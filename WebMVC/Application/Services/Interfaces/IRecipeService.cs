using WebMVC.Application.DTOs.Recipe;
using WebMVC.Application.Query;

namespace WebMVC.Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetAllAsync(RecipeQuery query);
        Task<RecipeDto?> GetByIdAsync(int id);
        Task<RecipeDto?> CreateAsync(CreateRecipeDto recipeCreateDto);
        Task<RecipeDto?> UpdateAsync(int id, UpdateRecipeDto recipeUpdateDto);
        Task DeleteAsync(int id);
    }
}
