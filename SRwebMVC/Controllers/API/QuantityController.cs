using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRwebMVC.Data;
using SRwebMVC.Entities;
using SRwebMVC.Models.DTOs;
/* Quantity API
 * GETS:
 * Get all quantities (paginated)
 * Get quantity by ID
 * 
 * POSTS:
 * Post a new quantity
 * 
 * PATCHES:
 * Patch an existing quantity (Name)
 * 
 * DELETES:
 * Delete a quantity by ID
 * 
 */
namespace SRwebMVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuantityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/quantity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuantityDto>>> GetQuantities([FromQuery] string? quantityName, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            IQueryable<Quantity> query = _context.Quantities.AsQueryable();
            if (!string.IsNullOrWhiteSpace(quantityName))
                query = query.Where(q => q.Name.ToLower().Contains(quantityName.ToLower()));
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var result = await query
                .Select(q => new QuantityDto
                {
                    Id = q.Id,
                    Name = q.Name
                })
                .ToListAsync();

            return result;
        }

        // GET: api/quantity/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<QuantityDto>> GetQuantity(int id)
        {
            var quantity = await _context.Quantities
                .Where(q => q.Id == id)
                .Select(q => new QuantityDto
                {
                    Id = q.Id,
                    Name = q.Name
                })
                .FirstOrDefaultAsync();

            if (quantity == null)
                return NotFound();

            return quantity;
        }

        // POST: api/quantity
        [HttpPost]
        public async Task<ActionResult<Quantity>> PostQuantity([FromBody] CreateQuantityDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Invalid quantity data.");
            }
            Quantity quantity = new Quantity { Name = dto.Name };
            _context.Quantities.Add(quantity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetQuantity), new { id = quantity.Id }, quantity);
        }

        // PATCH: api/quantity/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchQuantity(int id, [FromBody] EditQuantityDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Invalid quantity data.");
            }
            var quantity = await _context.Quantities.FindAsync(id);
            if (quantity == null)
            {
                return NotFound();
            }
            quantity.Name = dto.Name;
            _context.Entry(quantity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/quantity/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuantity(int id)
        {
            var quantity = await _context.Quantities.FindAsync(id);
            if (quantity == null)
            {
                return NotFound();
            }
            _context.Quantities.Remove(quantity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
