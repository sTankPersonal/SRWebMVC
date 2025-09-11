using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Application.ViewModels.Recipe;



namespace WebMVC.API.Controllers.Mvc
{
    [Route("[controller]")]
    public class RecipeController (IRecipeService recipeService) : Controller
    {
        private readonly IRecipeService _recipeService = recipeService;

        [HttpGet("")]
        public async Task<IActionResult> GetRecipes([FromQuery] string? searchName, [FromQuery] string? searchCategory, [FromQuery] string? searchIngredient, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            ListViewModel model = new ()
            {
                Recipes = await _recipeService.GetAllAsync(new Application.Query.RecipeQuery
                {
                    SearchName = searchName,
                    SearchCategory = searchCategory,
                    SearchIngredient = searchIngredient,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                })
            };
            return View("List", model);
        }



    }
}
