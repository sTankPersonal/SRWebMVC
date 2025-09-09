using WebMVC.Application.Query.Base;

namespace WebMVC.Application.Query
{
    public class UnitQuery : PagedQuery
    {
        public string? SearchName { get; set; }
    }
}
