using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Domain.Services.Validators
{
    public class UnitValidator : IUnitValidator
    {
        public Task ValidateAsync(Unit entity)
        {
            return Task.CompletedTask;
        }
        public Task ValidateCreateAsync(Unit entity)
        {
            return Task.CompletedTask;
        }
        public Task ValidateDeleteAsync(Unit entity)
        {
            return Task.CompletedTask;
        }
        public Task ValidateUpdateAsync(Unit entity)
        {
            return Task.CompletedTask;
        }
    }
}
