using Microsoft.EntityFrameworkCore;
using WebMVC.Application.Query;
using WebMVC.Application.Query.Base;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class UnitRepository(AppDbContext context) : IUnitRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Unit>> GetAllAsync(PagedQuery query)
        {
            return await _context.Units.Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize).ToListAsync();
        }
        public async Task<IEnumerable<Unit>> GetAllAsync(UnitQuery query)
        {
            IQueryable<Unit> units = _context.Units.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                units = units.Where(u => u.Name.Contains(query.SearchName, StringComparison.CurrentCultureIgnoreCase));
            }
            return await units.Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize).ToListAsync();
        }
        public async Task<Unit?> GetByIdAsync(int id)
        {
            return await _context.Units.FindAsync(id);
        }
        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Unit unit)
        {
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Unit unit)
        {
            _context.Remove(unit);
            await _context.SaveChangesAsync();
        }
    }
}
