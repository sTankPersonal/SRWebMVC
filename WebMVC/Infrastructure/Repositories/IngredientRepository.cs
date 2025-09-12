using Microsoft.EntityFrameworkCore;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Application.Query.Base;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class IngredientRepository(AppDbContext appDbContext) : IIngredientRepository
    {
        private readonly AppDbContext _context = appDbContext;
        public async Task<PagedResult<Ingredient>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Ingredient> ingredient = _context.Ingredients.AsQueryable();
            return new PagedResult<Ingredient>
            {
                Items = await ingredient.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await ingredient.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }
        public async Task<PagedResult<Ingredient>> GetAllAsync(IngredientQuery query)
        {
            IQueryable<Ingredient> ingredient = _context.Ingredients.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                ingredient = ingredient.Where(i => i.Name.Contains(query.SearchName, StringComparison.CurrentCultureIgnoreCase));
            }
            return new PagedResult<Ingredient>
            {
                Items = await ingredient.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await ingredient.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }
        public async Task<Ingredient?> GetByIdAsync(int id)
        {
            return await _context.Ingredients.FindAsync(id);
        }
        public async Task AddAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Ingredient ingredient)
        {
            _context.Remove(ingredient);
            await _context.SaveChangesAsync();
        }
    }
}
