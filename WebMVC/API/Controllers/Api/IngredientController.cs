using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.DTOs.Ingredient;
using WebMVC.Application.Query;
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
    public class IngredientController(IIngredientService ingredientService) : ControllerBase
    {
        private readonly IIngredientService _ingredientService = ingredientService;

        // GET: api/Ingredient
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredients([FromQuery] string? searchName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _ingredientService.GetAllAsync(new IngredientQuery
            {
                SearchName = searchName,
                PageNumber = pageNumber,
                PageSize = pageSize
            }));
        }
        // GET: api/Ingredient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> GetIngredient(int id)
        {
            return Ok(await _ingredientService.GetByIdAsync(id));
        }
        // POST: api/Ingredient
        [HttpPost("")]
        public async Task<ActionResult<IngredientDto>> CreateIngredient([FromBody] CreateIngredientDto ingredientCreateDto)
        {
            IngredientDto createdIngredient = await _ingredientService.CreateAsync(ingredientCreateDto);
            return CreatedAtAction(nameof(GetIngredient), new { id = createdIngredient.Id }, createdIngredient);
        }
        // PATCH: api/Ingredient/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] UpdateIngredientDto ingredientUpdateDto)
        {
            await _ingredientService.UpdateAsync(id, ingredientUpdateDto);
            return NoContent();
        }
        // DELETE: api/Ingredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await _ingredientService.DeleteAsync(id);
            return NoContent();
        }
    }
}