using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces;

namespace WebMVC.Domain.Services
{
    public class RecipeValidator : IRecipeValidator
    {
        public bool CanAddCategory(Recipe recipe, Category category)
        {
            return !recipe.RecipeCategories.Any(rc => rc.CategoryId == category.Id);
        }

        public bool CanAddIngredient(Recipe recipe, Ingredient ingredient)
        {
            return !recipe.RecipeIngredients.Any(ri => ri.IngredientId == ingredient.Id);
        }

        public bool CanAddInstructions(Recipe recipe, Instruction instruction)
        {
            return !recipe.Instructions.Any(i => i.StepNumber == instruction.StepNumber);
        }

        public bool CanRemoveCategory(Recipe recipe, Category category)
        {
            return recipe.RecipeCategories.Any(rc => rc.CategoryId == category.Id);
        }

        public bool CanRemoveIngredient(Recipe recipe, Ingredient ingredient)
        {
            return recipe.RecipeIngredients.Any(ri => ri.IngredientId == ingredient.Id);
        }

        public bool CanRemoveInstructions(Recipe recipe, Instruction instruction)
        {
            return recipe.Instructions.Any(i => i.Id == instruction.Id);
        }
    }
}
