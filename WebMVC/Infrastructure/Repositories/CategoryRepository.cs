using Microsoft.EntityFrameworkCore;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Application.Query.Base;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<PagedResult<Category>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Category> categories = _context.Categories.AsNoTracking().AsQueryable();
            return new PagedResult<Category>
            {
                Items = await categories
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await categories.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }

        public async Task<PagedResult<Category>> GetAllAsync(CategoryQuery query)
        {
            IQueryable<Category> categories = _context.Categories.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                categories = categories.Where(c => c.Name.Contains(query.SearchName, StringComparison.CurrentCultureIgnoreCase));
            }

            return new PagedResult<Category>
            {
                Items = await categories
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await categories.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
