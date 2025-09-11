using WebMVC.Application.DTOs.Unit;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;

namespace WebMVC.Application.Services.Implementations
{
    public class UnitService (IUnitRepository unitRepository, IUnitValidator unitValidator): IUnitService
    {
        private readonly IUnitRepository _unitRepository = unitRepository;
        private readonly IUnitValidator _unitValidator = unitValidator;
        public Task<IEnumerable<UnitDto>> GetAllAsync(UnitQuery query)
        {
            throw new NotImplementedException();
        }
        public Task<UnitDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<UnitDto> CreateAsync(CreateUnitDto unitCreateDto)
        {
            throw new NotImplementedException();
        }
        public Task<UnitDto> UpdateAsync(int id, UpdateUnitDto unitUpdateDto)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
