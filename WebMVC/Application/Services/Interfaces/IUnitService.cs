using WebMVC.Application.DTOs.Unit;
using WebMVC.Application.Query;

namespace WebMVC.Application.Services.Interfaces
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDto>> GetAllAsync(UnitQuery query);
        Task<UnitDto?> GetByIdAsync(int id);
        Task<UnitDto?> CreateAsync(CreateUnitDto unitCreateDto);
        Task<UnitDto?> UpdateAsync(int id, UpdateUnitDto unitUpdateDto);
        Task DeleteAsync(int id);
    }
}
