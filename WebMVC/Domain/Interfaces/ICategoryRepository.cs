using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllAsync(CategoryQuery query);
    }
}
