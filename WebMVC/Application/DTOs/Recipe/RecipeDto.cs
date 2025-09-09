using WebMVC.Application.DTOs.Category;
using WebMVC.Domain.Entities;
using WebMVC.Domain.ValueObjects;

namespace WebMVC.Application.DTOs.Recipe
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PrepTimeMinutes { get; set; }
        public int CookTimeMinutes { get; set; }
        public int Servings { get; set; }
        public ICollection<RecipeIngredientDto> Ingredients { get; set; } = [];
        public ICollection<CategoryDto> Categories { get; set; } = [];
        public ICollection<RecipeStepDto> Steps { get; set; } = [];
    }
}
