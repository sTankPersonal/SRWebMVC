using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Domain.Entities;
using WebMVC.Infrastructure.Data;
using WebMVC.Application.DTOs.Category;
using WebMVC.Application.Services.Implementations;

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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


    }
}
