using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.ViewModels.Recipe;
using WebMVC.Infrastructure.Repositories;


namespace WebMVC.API.Controllers.Mvc
{
    [Route("[controller]")]
    public class RecipeController : Controller
    {
        private readonly RecipeRepository _recipeRepository;

        public RecipeController(RecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ListViewModel>>> GetRecipies(string? searchName, string? searchIngredient, string? searchCategory, int pageNumber = 1, int pageSize = 10)
        {
            //var recipes = await _recipeRepository.GetPaginatedAsync(pageNumber, pageSize);
            //return Ok(recipes);
            return Ok();
        }



    }
}
