using Microsoft.EntityFrameworkCore;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Application.Query.Base;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class RecipeRepository(AppDbContext appDbContext) : IRecipeRepository
    {
        private readonly AppDbContext _context = appDbContext;
        public async Task<PagedResult<Recipe>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Recipe> recipes = _context.Recipes.AsQueryable();
            return new PagedResult<Recipe>
            {
                Items = await recipes.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await recipes.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }
        public async Task<PagedResult<Recipe>> GetAllAsync(RecipeQuery query)
        {
            IQueryable<Recipe> recipes = _context.Recipes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                recipes = recipes.Where(r => r.Name.Contains(query.SearchName, StringComparison.CurrentCultureIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(query.SearchIngredient))
            {
                recipes = recipes.Where(r =>
                    r.RecipeIngredients.Any(ri =>
                        ri.Ingredient.Name.Contains(query.SearchIngredient, StringComparison.CurrentCultureIgnoreCase)
                    )
                );
            }
            if (!string.IsNullOrWhiteSpace(query.SearchCategory))
            {
                recipes = recipes.Where(r =>
                    r.RecipeCategories.Any(c =>
                        c.Category.Name.Contains(query.SearchCategory, StringComparison.CurrentCultureIgnoreCase)
                    )
                );
            }
            return new PagedResult<Recipe>
            {
                Items = await recipes.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await recipes.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }
        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }
        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Recipe recipe)
        {
            _context.Remove(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
