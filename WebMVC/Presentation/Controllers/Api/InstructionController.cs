using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.DTOs.Ingredient;
using WebMVC.Application.DTOs.Instruction;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;
using WebMVC.Application.Services.Interfaces;

namespace WebMVC.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController (IInstructionService instructionService): ControllerBase
    {
        private readonly IInstructionService _instructionService = instructionService;

        // GET: api/Instruction
        [HttpGet("")]
        public async Task<ActionResult<PagedResult<InstructionDto>>> GetInstructions([FromQuery] string? searchDescription, [FromQuery] int stepNumber = 0, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _instructionService.GetAllAsync(new InstructionQuery
            {
                SearchDescription = searchDescription,
                StepNumber = stepNumber,
                PageNumber = pageNumber,
                PageSize = pageSize
            }));
        }
        // GET: api/Instruction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructionDto>> GetInstruction(int id)
        {
            return Ok(await _instructionService.GetByIdAsync(id));
        }
        // POST: api/Instruction
        [HttpPost("")]
        public async Task<ActionResult<IngredientDto>> CreateInstruction([FromBody] CreateInstructionDto instructionCreateDto)
        {
            var createdInstruction = await _instructionService.CreateAsync(instructionCreateDto);
            return CreatedAtAction(nameof(GetInstruction), new { id = createdInstruction.Id }, createdInstruction);
        }
        // PATCH: api/Instruction/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateInstruction(int id, [FromBody] UpdateInstructionDto instructionUpdateDto)
        {
            await _instructionService.UpdateAsync(id, instructionUpdateDto);
            return NoContent();
        }
        // DELETE: api/Instruction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstruction(int id)
        {
            await _instructionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
