using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IUnitRepository : IEntityRepository<Unit>
    {
        Task<IEnumerable<Unit>> GetAllAsync(UnitQuery query);
    }
}
