using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.DTOs.Category;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Services.Implementations;
using WebMVC.Application.Services.Interfaces;

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
namespace WebMVC.API.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController (ICategoryService categoryService): ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        // GET: api/Category
        [HttpGet("")]
        public async Task<ActionResult<PagedResult<CategoryDto>>> GetCategories([FromQuery] string? searchName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _categoryService.GetAllAsync(new Application.Query.CategoryQuery
            {
                SearchName = searchName,
                PageNumber = pageNumber,
                PageSize = pageSize
            }));
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        // POST: api/Category
        [HttpPost("")]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryDto categoryCreateDto)
        {
            CategoryDto createdCategory = await _categoryService.CreateAsync(categoryCreateDto);
            return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
        }

        // PATCH: api/Category/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto categoryUpdateDto)
        {
            await _categoryService.UpdateAsync(id, categoryUpdateDto);
            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
