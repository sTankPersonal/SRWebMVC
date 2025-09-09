using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces
{
    public interface IUnitRepository : IEntityRepository<Unit>
    {
        Task<IEnumerable<Unit>> GetAllAsync(UnitQuery query);
    }
}
