using Microsoft.AspNetCore.Mvc;
using SRwebMVC.Data;
using SRwebMVC.Entities;
using SRwebMVC.Models.DTOs;

namespace SRwebMVC.Controllers.API
{
    /* RecipeStep API
     * TBD If this is required, otherwise it can be removed.
     */
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeStepController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RecipeStepController(AppDbContext context)
        {
            _context = context;
        }
    }
}
