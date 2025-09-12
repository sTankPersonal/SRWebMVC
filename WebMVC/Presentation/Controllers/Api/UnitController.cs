using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.DTOs.Unit;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;

/* Unit API
 * 
 * GETS:
 * Get all units (paginated)
 * Get unit by ID
 * 
 * POST:
 * Create a new unit
 * 
 * PATCH:
 * Edit an existing unit (Name)
 * 
 * DELETE:
 * Delete a unit by ID
 * 
 */
namespace WebMVC.API.Controllers.Api
{
    public class UnitController (IUnitService unitService): ControllerBase
    {
        private readonly IUnitService _unitService = unitService;
        // GET: api/Unit
        [HttpGet("api/[controller]")]
        public async Task<ActionResult<PagedResult<UnitDto>>> GetUnits([FromQuery] string? searchName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _unitService.GetAllAsync(new UnitQuery
            {
                SearchName = searchName,
                PageNumber = pageNumber,
                PageSize = pageSize
            }));
        }

        // GET: api/Unit/5
        [HttpGet("api/[controller]/{id}")]
        public async Task<ActionResult<UnitDto>> GetUnit(int id)
        {
            return Ok(await _unitService.GetByIdAsync(id));
        }
        // POST: api/Unit
        [HttpPost("api/[controller]")]
        public async Task<ActionResult<UnitDto>> CreateUnit([FromBody] CreateUnitDto unitCreateDto)
        {
            var createdUnit = await _unitService.CreateAsync(unitCreateDto);
            return CreatedAtAction(nameof(GetUnit), new { id = createdUnit.Id }, createdUnit);
        }
        // PATCH: api/Unit/5
        [HttpPatch("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateUnit(int id, [FromBody] UpdateUnitDto unitUpdateDto)
        {
            await _unitService.UpdateAsync(id, unitUpdateDto);
            return NoContent();
        }
        // DELETE: api/Unit/5
        [HttpDelete("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            await _unitService.DeleteAsync(id);
            return NoContent();
        }
    }
}
