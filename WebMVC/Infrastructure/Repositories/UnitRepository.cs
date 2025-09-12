using Microsoft.EntityFrameworkCore;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Application.Query.Base;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class UnitRepository(AppDbContext context) : IUnitRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<PagedResult<Unit>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Unit> units = _context.Units.AsQueryable();
            return new PagedResult<Unit>
            {
                Items = await units.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await units.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }
        public async Task<PagedResult<Unit>> GetAllAsync(UnitQuery query)
        {
            IQueryable<Unit> units = _context.Units.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                units = units.Where(u => u.Name.Contains(query.SearchName, StringComparison.CurrentCultureIgnoreCase));
            }
            return new PagedResult<Unit>
            {
                Items = await units.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await units.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
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
