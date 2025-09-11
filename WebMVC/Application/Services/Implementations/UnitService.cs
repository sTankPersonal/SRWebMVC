using WebMVC.Application.DTOs.Unit;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;

namespace WebMVC.Application.Services.Implementations
{
    public class UnitService : IUnitService
    {
        public Task<IEnumerable<UnitDto>> GetAllAsync(UnitQuery query)
        {
            throw new NotImplementedException();
        }
        public Task<UnitDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<UnitDto?> CreateAsync(CreateUnitDto unitCreateDto)
        {
            throw new NotImplementedException();
        }
        public Task<UnitDto?> UpdateAsync(int id, UpdateUnitDto unitUpdateDto)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
