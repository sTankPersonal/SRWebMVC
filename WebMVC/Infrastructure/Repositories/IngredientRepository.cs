using Microsoft.EntityFrameworkCore;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class IngredientRepository(AppDbContext appDbContext) : IIngredientRepository
    {
        private readonly AppDbContext _context = appDbContext;
        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients.ToListAsync();
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
