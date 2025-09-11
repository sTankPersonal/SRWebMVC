using WebMVC.Application.DTOs.Instruction;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;
using WebMVC.Infrastructure.Repositories;

namespace WebMVC.Application.Services.Implementations
{
    public class InstructionService(IInstructionRepository instructionRepository, IInstructionValidator instructionValidator) : IInstructionService
    {
        private readonly IInstructionRepository _instructionRepository = instructionRepository;
        private readonly IInstructionValidator instructionValidator = instructionValidator;

        public async Task<IEnumerable<InstructionDto>> GetAllAsync(InstructionQuery query)
        {
            IEnumerable<Instruction> instructions = await _instructionRepository.GetAllAsync(query);
            return instructions.Select(i => new InstructionDto
            {
                Id = i.Id,
                Description = i.Description,
                StepNumber = i.StepNumber
            });
        }
        public async Task<InstructionDto?> GetByIdAsync(int id)
        {
            Instruction? instruction = await _instructionRepository.GetByIdAsync(id);
            if (instruction == null)
                return null;
            return new InstructionDto
            {
                Id = instruction.Id,
                Description = instruction.Description,
                StepNumber = instruction.StepNumber
            };
        }
        public async Task<InstructionDto?> CreateAsync(CreateInstructionDto instructionCreateDto)
        {
            Instruction instruction = new()
            {
                RecipeId = instructionCreateDto.recipeId,
                Recipe = null!, // To be set by EF Core
                Description = instructionCreateDto.Description,
                StepNumber = instructionCreateDto.StepNumber
            };
            await instructionValidator.ValidateCreateAsync(instruction);
            await _instructionRepository.AddAsync(instruction);
            return new InstructionDto
            {
                Id = instruction.Id,
                Description = instruction.Description,
                StepNumber = instruction.StepNumber
            };
        }
        public async Task<InstructionDto?> UpdateAsync(int id, UpdateInstructionDto instructionUpdateDto)
        {
            Instruction? instruction = await _instructionRepository.GetByIdAsync(id);
            if (instruction == null)
                return null;
            instruction.Description = instructionUpdateDto.Description;
            instruction.StepNumber = instructionUpdateDto.StepNumber;
            await instructionValidator.ValidateUpdateAsync(instruction);
            await _instructionRepository.UpdateAsync(instruction);
            return new InstructionDto
            {
                Id = instruction.Id,
                Description = instruction.Description,
                StepNumber = instruction.StepNumber
            };
        }
        public async Task DeleteAsync(int id)
        {
            Instruction? instruction = await _instructionRepository.GetByIdAsync(id);
            if (instruction == null)
                return;
            await _instructionRepository.DeleteAsync(instruction);
        }
    }
}
