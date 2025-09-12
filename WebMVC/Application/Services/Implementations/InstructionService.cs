using WebMVC.Application.DTOs.Instruction;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Application.Services.Implementations
{
    public class InstructionService(IInstructionRepository instructionRepository, IInstructionValidator instructionValidator) : IInstructionService
    {
        private readonly IInstructionRepository _instructionRepository = instructionRepository;
        private readonly IInstructionValidator instructionValidator = instructionValidator;

        public async Task<PagedResult<InstructionDto>> GetAllAsync(InstructionQuery query)
        {
            PagedResult<Instruction> instructions = await _instructionRepository.GetAllAsync(query);
            return new PagedResult<InstructionDto>
            {
                Items = instructions.Items.Select(i => new InstructionDto
                {
                    Id = i.Id,
                    Description = i.Description,
                    StepNumber = i.StepNumber
                }),
                TotalCount = instructions.TotalCount,
                PageNumber = instructions.PageNumber,
                PageSize = instructions.PageSize
            };
        }
        public async Task<InstructionDto> GetByIdAsync(int id)
        {
            Instruction? instruction = await _instructionRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Instruction with ID {id} not found.");
            return new InstructionDto
            {
                Id = instruction.Id,
                Description = instruction.Description,
                StepNumber = instruction.StepNumber
            };
        }
        public async Task<InstructionDto> CreateAsync(CreateInstructionDto instructionCreateDto)
        {
            Instruction instruction = new()
            {
                RecipeId = instructionCreateDto.recipeId,
                Recipe = null!,                         // This will hopefully be set by EF Core when the instruction is added to the context. No promises
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
        public async Task<InstructionDto> UpdateAsync(int id, UpdateInstructionDto instructionUpdateDto)
        {
            Instruction? instruction = await _instructionRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Instruction with ID {id} not found.");
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
            Instruction? instruction = await _instructionRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Instruction with ID {id} not found.");
            await instructionValidator.ValidateDeleteAsync(instruction);
            await _instructionRepository.DeleteAsync(instruction);
        }
    }
}
