using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Domain.Services.Validators
{
    public class InstructionValidator : IInstructionValidator
    {
        public Task ValidateAsync(Instruction entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateCreateAsync(Instruction entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateDeleteAsync(Instruction entity)
        {
            return Task.CompletedTask;
        }

        public Task ValidateUpdateAsync(Instruction entity)
        {
            return Task.CompletedTask;
        }
    }
}
