using WebMVC.Application.DTOs.Category;

namespace WebMVC.Application.Services.Interfaces
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
