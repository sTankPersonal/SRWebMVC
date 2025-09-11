using System.ComponentModel.DataAnnotations;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Domain.Services.Validators
{
    public class CategoryValidator(ICategoryRepository categoryRepository) : ICategoryValidator
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        public Task ValidateAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ValidationException("Category name is required.");
            return Task.CompletedTask;
        }

        public async Task ValidateCreateAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ValidationException("Category name is required.");
            if (await _categoryRepository.ExistsByNameAsync(category.Name))
                throw new ValidationException("Category name must be unique.");
        }

        public Task ValidateDeleteAsync(Category category)
        {
            return Task.CompletedTask;
        }

        public Task ValidateUpdateAsync(Category category)
        {
            return Task.CompletedTask;
        }
    }
}
