using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRwebMVC.Data;
using SRwebMVC.Entities;
using SRwebMVC.Models.DTOs;
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
namespace SRwebMVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ingredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredients([FromQuery] string? ingredientName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            IQueryable<Ingredient> query = _context.Ingredients.AsQueryable();
            if (!string.IsNullOrWhiteSpace(ingredientName))
                query = query.Where(i => i.Name.Contains(ingredientName));
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var result = await query
                .Select(i => new IngredientDto
                {
                    Id = i.Id,
                    Name = i.Name
                })
                .ToListAsync();

            return result;
        }

        // GET: api/ingredient/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients
                .Where(i => i.Id == id)
                .Select(i => new IngredientDto
                {
                    Id = i.Id,
                    Name = i.Name
                })
                .FirstOrDefaultAsync();

            if (ingredient == null)
                return NotFound();

            return ingredient;
        }

        // POST: api/ingredient
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient([FromBody] CreateIngredientDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Invalid ingredient data.");
            }
            Ingredient ingredient = new Ingredient { Name = dto.Name };
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
        }

        // PATCH: api/ingredient/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchIngredient(int id, [FromBody] EditIngredientDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Invalid ingredient data.");
            }
            var existingIngredient = await _context.Ingredients.FindAsync(id);
            if (existingIngredient == null)
            {
                return NotFound();
            }
            existingIngredient.Name = dto.Name;
            _context.Ingredients.Update(existingIngredient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/ingredient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
