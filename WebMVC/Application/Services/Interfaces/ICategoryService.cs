using WebMVC.Application.DTOs.Category;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;

namespace WebMVC.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedResult<CategoryDto>> GetAllAsync(CategoryQuery query);
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto categoryCreateDto);
        Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto categoryUpdateDto);
        Task DeleteAsync(int id);
    }
}
