using WebMVC.Application.Query;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllAsync(CategoryQuery query);
        Task<bool> ExistsByNameAsync(string name);
    }
}
