using WebMVC.Application.DTOs.Instruction;
using WebMVC.Application.Query;

namespace WebMVC.Application.Services.Interfaces
{
    public interface IInstructionService
    {
        Task<IEnumerable<InstructionDto>> GetAllAsync(InstructionQuery query);
        Task<InstructionDto?> GetByIdAsync(int id);
        Task<InstructionDto?> CreateAsync(CreateInstructionDto instructionCreateDto);
        Task<InstructionDto?> UpdateAsync(int id, UpdateInstructionDto instructionUpdateDto);
        Task DeleteAsync(int id);
    }
}
