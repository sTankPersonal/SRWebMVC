using Microsoft.AspNetCore.Mvc;
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

    }
}
