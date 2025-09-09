using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IInstructionRepository : IEntityRepository<Instruction>
    {
        Task<IEnumerable<Instruction>> GetAllAsync(IngredientQuery query);
    }
}
