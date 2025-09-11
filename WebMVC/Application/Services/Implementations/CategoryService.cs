using System.Reflection.Metadata.Ecma335;
using WebMVC.Application.DTOs.Category;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Application.Services.Implementations
{
    public class CategoryService(ICategoryRepository categoryRepository, ICategoryValidator categoryValidator) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly ICategoryValidator _categoryValidator = categoryValidator;

        public async Task<IEnumerable<CategoryDto>> GetAllAsync(CategoryQuery query)
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync(query);
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return null;
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task<CategoryDto?> CreateAsync(CreateCategoryDto categoryCreateDto)
        {
            Category category = new ()
            {
                Name = categoryCreateDto.Name
            };
            await _categoryValidator.ValidateCreateAsync(category);
            await _categoryRepository.AddAsync(category);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto categoryUpdateDto)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return null;

            category.Name = categoryUpdateDto.Name;
            await _categoryValidator.ValidateUpdateAsync(category);
            await _categoryRepository.UpdateAsync(category);
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
            await _categoryValidator.ValidateDeleteAsync(category);
            await _categoryRepository.DeleteAsync(category);
        }
    }
}
