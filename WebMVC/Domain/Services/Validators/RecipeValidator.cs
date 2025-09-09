using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Domain.Services.Validators
{
    public class RecipeValidator : IRecipeValidator
    {
        public Task ValidateAsync(Recipe entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateCreateAsync(Recipe entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateDeleteAsync(Recipe entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateUpdateAsync(Recipe entity)
        {
            return Task.CompletedTask;
        }
    }
}
