using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.DTOs.Recipe;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Application.ViewModels.Recipe;

/* View Controller for managing recipes.
 * 
 * Get a list of recipes with optional search and pagination.
 * Get recipe details by ID.
 * 
 * Get the Create Recipe form.
 * Post a new recipe.
 * 
 * Get the Edit Recipe form by ID.
 * Put an existing recipe by ID.
 * 
 * WIP: Attaching ingredients, categories, and instructions to recipes.
 * 
 * Get the Delete Recipe confirmation by ID.
 * Delete a recipe by ID
 */
namespace WebMVC.Presentation.Endpoints.Http
{
    [Route("[controller]")]
    public class RecipeController (IRecipeService recipeService) : Controller
    {
        private readonly IRecipeService _recipeService = recipeService;

        [HttpGet("")]
        public async Task<IActionResult> GetRecipes([FromQuery] string? searchName, [FromQuery] string? searchCategory, [FromQuery] string? searchIngredient, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            RecipeQuery query = new()
            {
                SearchName = searchName,
                SearchCategory = searchCategory,
                SearchIngredient = searchIngredient,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            ListViewModel model = new ()
            {
                Recipes = await _recipeService.GetAllAsync(query),
                Query = query
            };
            return View("List", model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            RecipeDto recipe = await _recipeService.GetByIdAsync(id);

            return View("Details", recipe);
        }



        [HttpGet("create")]
        public IActionResult CreateRecipe()
        {
            return View("Create");
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateRecipe([FromForm] CreateRecipeDto createRecipeDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", createRecipeDto);
            }
            RecipeDto createdRecipe = await _recipeService.CreateAsync(createRecipeDto);
            return RedirectToAction("GetRecipeById", new { id = createdRecipe.Id });
        }



        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> EditRecipe(int id)
        {
            RecipeDto recipe = await _recipeService.GetByIdAsync(id);
            UpdateRecipeDto updateRecipeDto = new()
            {
                Name = recipe.Name,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                CookTimeMinutes = recipe.CookTimeMinutes,
                Servings = recipe.Servings
            };
            return View("Edit", updateRecipeDto);
        }
        [HttpPost("edit/{id:int}")]
        public async Task<IActionResult> EditRecipe(int id, [FromForm] UpdateRecipeDto updateRecipeDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", updateRecipeDto);
            }
            RecipeDto updatedRecipe = await _recipeService.UpdateAsync(id, updateRecipeDto);
            return RedirectToAction("GetRecipeById", new { id = updatedRecipe.Id });
        }


        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            RecipeDto recipe = await _recipeService.GetByIdAsync(id);
            return View("Delete", recipe);
        }
        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> DeleteRecipeConfirmed(int id)
        {
            await _recipeService.DeleteAsync(id);
            return RedirectToAction("GetRecipes");
        }
    }
}
