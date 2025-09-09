using WebMVC.Application.Query.Base;

namespace WebMVC.Application.Query
{
    public class IngredientQuery : PagedQuery
    {
        public string? SearchName { get; set; }
    }
}
