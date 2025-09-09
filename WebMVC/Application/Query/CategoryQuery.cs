using WebMVC.Application.Query.Base;

namespace WebMVC.Application.Query
{
    public class CategoryQuery : PagedQuery
    {
        public string? SearchName { get; init; }
    }
}
