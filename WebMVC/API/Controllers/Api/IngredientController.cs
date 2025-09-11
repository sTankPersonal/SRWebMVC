using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.Services.Interfaces;
/* Ingredient API
 * 
 * GETS:
 * Get all ingredients (paginated)
 * Get ingredient by ID
 * 
 * POST:
 * Create a new ingredient
 * 
 * PATCH:
 * Edit an existing ingredient (Name)
 * 
 * DELETE:
 * Delete an ingredient by ID
 * 
 */
namespace WebMVC.API.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController (IIngredientService ingredientService): ControllerBase
    {
        private readonly IIngredientService _ingredientService = ingredientService;
    }
}
