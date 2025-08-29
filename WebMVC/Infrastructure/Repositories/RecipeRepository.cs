using Microsoft.EntityFrameworkCore;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class RecipeRepository(AppDbContext appDbContext) : IRecipeRepository
    {
        private readonly AppDbContext _context = appDbContext;
        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _context.Recipes.ToListAsync();
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
