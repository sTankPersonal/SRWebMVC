using Microsoft.EntityFrameworkCore;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Application.Query.Base;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Infrastructure.Data;

namespace WebMVC.Infrastructure.Repositories
{
    public class InstructionRepository(AppDbContext appDbContext) : IInstructionRepository
    {
        private readonly AppDbContext _context = appDbContext;

        public async Task<PagedResult<Instruction>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Instruction> instructions = _context.Instructions.AsQueryable();
            return new PagedResult<Instruction>
            {
                Items = await instructions.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await instructions.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }
        public async Task<PagedResult<Instruction>> GetAllAsync(InstructionQuery query)
        {
            IQueryable<Instruction> instructions = _context.Instructions.AsQueryable();
            if (query.StepNumber > 0)
            {
                instructions = instructions.Where(i => i.StepNumber == query.StepNumber);
            }
            if (!string.IsNullOrWhiteSpace(query.SearchDescription))
            {
                instructions = instructions.Where(i => i.Description.Contains(query.SearchDescription, StringComparison.CurrentCultureIgnoreCase));
            }
            return new PagedResult<Instruction>
            {
                Items = await instructions.Skip((query.PageNumber - 1) * query.PageSize)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(),
                TotalCount = await instructions.CountAsync(),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }
        public async Task<Instruction?> GetByIdAsync(int id)
        {
            return await _context.Instructions.FindAsync(id);
        }
        public async Task AddAsync(Instruction instruction)
        {
            await _context.Instructions.AddAsync(instruction);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Instruction instruction)
        {
            _context.Instructions.Update(instruction);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Instruction instruction)
        {
            _context.Remove(instruction);
            await _context.SaveChangesAsync();
        }
    }
}
