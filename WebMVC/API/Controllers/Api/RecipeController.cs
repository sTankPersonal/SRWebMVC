using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.Services.Interfaces;
/* Recipes API
 * 
 * GETS:
 * Get all recipes (paginated)
 * - Query parameters for searching by name, category, ingredient, etc.
 * Get recipe by ID
 * 
 * POST:
 * Post a new recipe
 * 
 * PATCH:
 * Add a new ingredient to a recipe
 * Add a new category to a recipe
 * Add a new step to a recipe
 * Edit an existing recipe
 * 
 * DELETE:
 * Delete a recipe
 * Remove an ingredient from a recipe
 * Remove a category from a recipe
 * Remove a step from a recipe
 * 
 */
namespace WebMVC.API.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController (IRecipeService recipeService): ControllerBase
    {
        private readonly IRecipeService _recipeService = recipeService;
    }
}
