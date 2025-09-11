using WebMVC.Application.Query.Base;

namespace WebMVC.Application.Query
{
    public class IngredientQuery : PagedQuery
    {
        public int StepNumber { get; set; }
        public string? SearchText { get; set; }
    }
}
