using WebMVC.Application.DTOs.Ingredient;
using WebMVC.Application.Query;

namespace WebMVC.Application.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetAllAsync(IngredientQuery query);
        Task<IngredientDto> GetByIdAsync(int id);
        Task<IngredientDto> CreateAsync(CreateIngredientDto ingredientCreateDto);
        Task<IngredientDto> UpdateAsync(int id, UpdateIngredientDto ingredientUpdateDto);
        Task DeleteAsync(int id);
    }
}
