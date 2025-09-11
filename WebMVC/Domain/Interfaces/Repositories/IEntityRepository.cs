using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query.Base;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        Task<PagedResult<T>> GetAllAsync(PagedQuery query);
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
