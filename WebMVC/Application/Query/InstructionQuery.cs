using WebMVC.Application.Query.Base;

namespace WebMVC.Application.Query
{
    public class InstructionQuery : PagedQuery
    {
        public int StepNumber { get; set; }
        public string? SearchDescription { get; set; }
    }
}
