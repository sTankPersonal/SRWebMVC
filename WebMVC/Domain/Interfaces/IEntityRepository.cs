namespace WebMVC.Domain.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        Task<T> GetByIdAsyncy(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
