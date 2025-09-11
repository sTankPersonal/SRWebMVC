using WebMVC.Application.DTOs.Recipe;

namespace WebMVC.Application.ViewModels.Recipe
{
    public class ListViewModel
    {
        public IEnumerable<RecipeDto> Recipes { get; set; } = [];
    }
}
