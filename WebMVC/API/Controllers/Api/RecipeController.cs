using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.DTOs.Recipe;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
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
    public class RecipeController(IRecipeService recipeService) : ControllerBase
    {
        private readonly IRecipeService _recipeService = recipeService;
        // GET: api/Recipe
        [HttpGet("")]
        public async Task<ActionResult<PagedResult<RecipeDto>>> GetRecipes([FromQuery] string? searchName, [FromQuery] string? searchCategory, [FromQuery] string? searchIngredient, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _recipeService.GetAllAsync(new RecipeQuery
            {
                SearchName = searchName,
                SearchCategory = searchCategory,
                SearchIngredient = searchIngredient,
                PageNumber = pageNumber,
                PageSize = pageSize
            }));
        }
        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
            return Ok(await _recipeService.GetByIdAsync(id));
        }
        // POST: api/Recipe
        [HttpPost("")]
        public async Task<ActionResult<RecipeDto>> CreateRecipe([FromBody] CreateRecipeDto recipeCreateDto)
        {
            var createdRecipe = await _recipeService.CreateAsync(recipeCreateDto);
            return CreatedAtAction(nameof(GetRecipe), new { id = createdRecipe.Id }, createdRecipe);
        }
        // PATCH: api/Recipe/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] UpdateRecipeDto recipeUpdateDto)
        {
            await _recipeService.UpdateAsync(id, recipeUpdateDto);
            return NoContent();
        }
        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _recipeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
