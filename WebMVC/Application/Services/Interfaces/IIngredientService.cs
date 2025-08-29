namespace WebMVC.Application.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync();
        Task<IngredientDto> GetIngredientByIdAsync(int id);
        Task<IngredientDto> CreateIngredientAsync(IngredientCreateDto ingredientCreateDto);
        Task<IngredientDto> UpdateIngredientAsync(int id, IngredientUpdateDto ingredientUpdateDto);
        Task<bool> DeleteIngredientAsync(int id);
    }
}
