using WebMVC.Application.DTOs.Instruction;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;

namespace WebMVC.Application.Services.Interfaces
{
    public interface IInstructionService
    {
        Task<PagedResult<InstructionDto>> GetAllAsync(InstructionQuery query);
        Task<InstructionDto> GetByIdAsync(int id);
        Task<InstructionDto> CreateAsync(CreateInstructionDto instructionCreateDto);
        Task<InstructionDto> UpdateAsync(int id, UpdateInstructionDto instructionUpdateDto);
        Task DeleteAsync(int id);
    }
}
