using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Domain.Services.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        public Task ValidateAsync(Category entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateCreateAsync(Category entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateDeleteAsync(Category entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateUpdateAsync(Category entity)
        {
            return Task.CompletedTask;
        }
    }
}
