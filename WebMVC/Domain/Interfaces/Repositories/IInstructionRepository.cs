using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IInstructionRepository : IEntityRepository<Instruction>
    {
        Task<PagedResult<Instruction>> GetAllAsync(InstructionQuery query);
    }
}
