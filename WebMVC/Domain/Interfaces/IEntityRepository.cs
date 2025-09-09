using WebMVC.Application.Query.Base;

namespace WebMVC.Domain.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(PagedQuery query);
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
