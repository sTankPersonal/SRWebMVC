using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRwebMVC.Data;
using SRwebMVC.Entities;
using SRwebMVC.Models.DTOs;

/* Category API
 * 
 * GETS:
 * Get all categories (paginated)
 * Get category by ID
 * 
 * POST:
 * Create a new category
 * 
 * PATCH:
 * Edit an existing category (Name)
 * 
 * DELETE:
 * Delete a category 
 * 
 */
namespace SRwebMVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories([FromQuery] string? categoryName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            IQueryable<Category> query = _context.Categories.AsQueryable();
            if (!string.IsNullOrWhiteSpace(categoryName))
                query = query.Where(c => c.Name.ToLower().Contains(categoryName.ToLower()));
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var result = await query
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return result;
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefaultAsync();

            if (category == null)
                return NotFound();

            return category;
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromBody] CreateCategoryDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Category name is required.");
            }
            Category category = new Category { Name = dto.Name };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PATCH: api/category/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCategory(int id, [FromBody] EditCategoryDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Category name is required.");
            }
            Category? existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = dto.Name;
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
