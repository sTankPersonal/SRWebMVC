using WebMVC.Application.Query.Base;

namespace WebMVC.Application.Query
{
    public class InstructionQuery : PagedQuery
    {
        public string? SearchDescription { get; set; }
    }
}
