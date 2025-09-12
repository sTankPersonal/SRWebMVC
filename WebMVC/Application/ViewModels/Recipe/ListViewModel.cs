using WebMVC.Application.DTOs.Recipe;
using WebMVC.Application.DTOs.Shared;
using WebMVC.Application.Query;

namespace WebMVC.Application.ViewModels.Recipe
{
    public class ListViewModel
    {
        public PagedResult<RecipeDto> Recipes { get; set; } = new();
        public RecipeQuery Query { get; set; } = new();
    }
}
