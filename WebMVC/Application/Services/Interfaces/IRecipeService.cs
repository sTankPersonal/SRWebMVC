namespace WebMVC.Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        Task<RecipeDto> GetRecipeByIdAsync(int id);
        Task<RecipeDto> CreateRecipeAsync(RecipeCreateDto recipeCreateDto);
        Task<RecipeDto> UpdateRecipeAsync(int id, RecipeUpdateDto recipeUpdateDto);
        Task<bool> DeleteRecipeAsync(int id);
    }
}
