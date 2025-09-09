using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Domain.Services.Validators
{
    public class IngredientValidator : IIngredientValidator
    {
        public Task ValidateAsync(Ingredient entity)
        {
            return Task.CompletedTask;
        }
        public Task ValidateCreateAsync(Ingredient entity)
        {
            return Task.CompletedTask;
        }
        public Task ValidateDeleteAsync(Ingredient entity)
        {
            return Task.CompletedTask;
        }
        public Task ValidateUpdateAsync(Ingredient entity)
        {
            return Task.CompletedTask;
        }
    }
}
