using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IUnitRepository : IEntityRepository<Unit>
    {
        Task<PagedResult<Unit>> GetAllAsync(UnitQuery query);
    }
}
