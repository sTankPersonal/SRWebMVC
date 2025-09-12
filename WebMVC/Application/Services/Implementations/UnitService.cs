using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.DTOs.Unit;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Application.Services.Implementations
{
    public class UnitService (IUnitRepository unitRepository, IUnitValidator unitValidator): IUnitService
    {
        private readonly IUnitRepository _unitRepository = unitRepository;
        private readonly IUnitValidator _unitValidator = unitValidator;
        public async Task<PagedResult<UnitDto>> GetAllAsync(UnitQuery query)
        {
            PagedResult<Unit> units = await _unitRepository.GetAllAsync(query);
            return new PagedResult<UnitDto>
            {
                Items = units.Items.Select(u => new UnitDto
                {
                    Id = u.Id,
                    Name = u.Name
                }),
                TotalCount = units.TotalCount,
                PageNumber = units.PageNumber,
                PageSize = units.PageSize
            };
        }
        public async Task<UnitDto> GetByIdAsync(int id)
        {
            Unit unit = await _unitRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Unit with id {id} not found.");
            return new UnitDto
            {
                Id = unit.Id,
                Name = unit.Name
            };
        }
        public async Task<UnitDto> CreateAsync(CreateUnitDto unitCreateDto)
        {
            Unit unit = new()
            {
                Name = unitCreateDto.Name
            };
            await _unitValidator.ValidateCreateAsync(unit);
            await _unitRepository.AddAsync(unit);
            return new UnitDto
            {
                Id = unit.Id,
                Name = unit.Name
            };
        }
        public async Task<UnitDto> UpdateAsync(int id, UpdateUnitDto unitUpdateDto)
        {
            Unit unit = await _unitRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Unit with id {id} not found.");
            unit.Name = unitUpdateDto.Name;
            await _unitValidator.ValidateUpdateAsync(unit);
            await _unitRepository.UpdateAsync(unit);
            return new UnitDto
            {
                Id = unit.Id,
                Name = unit.Name
            };
        }
        public async Task DeleteAsync(int id)
        {
            Unit unit = await _unitRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Unit with id {id} not found.");
            await _unitValidator.ValidateDeleteAsync(unit);
            await _unitRepository.DeleteAsync(unit);
        }
    }
}
