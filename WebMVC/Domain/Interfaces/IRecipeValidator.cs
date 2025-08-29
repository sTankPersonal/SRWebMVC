using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces
{
    public interface IRecipeValidator : IEntityValidator<Recipe>
    {
        bool CanAddIngredient(Recipe recipe, Ingredient ingredient);
        bool CanRemoveIngredient(Recipe recipe, Ingredient ingredient);
        bool CanAddInstructions(Recipe recipe, Instruction instruction);
        bool CanRemoveInstructions(Recipe recipe, Instruction instruction);
        bool CanAddCategory(Recipe recipe, Category category);
        bool CanRemoveCategory(Recipe recipe, Category category);
    }
}
