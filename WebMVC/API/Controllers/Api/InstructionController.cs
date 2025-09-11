using Microsoft.AspNetCore.Mvc;
using WebMVC.Application.Services.Interfaces;

namespace WebMVC.API.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController (IInstructionService instructionService): ControllerBase
    {
        private readonly IInstructionService _instructionService = instructionService;
    }
}
