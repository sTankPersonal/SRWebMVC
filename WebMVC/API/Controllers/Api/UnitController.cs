using Microsoft.AspNetCore.Mvc;
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
    }
}
