using WebMVC.Application.Query.Base;

namespace WebMVC.Application.Query
{
    public class RecipeQuery : PagedQuery
    {
        public string? SearchName { get; init; }
        public string? SearchIngredient { get; init; }
        public string? SearchCategory { get; init; }
    }
}
