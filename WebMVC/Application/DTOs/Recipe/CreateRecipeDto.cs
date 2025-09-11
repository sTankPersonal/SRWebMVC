using WebMVC.Application.DTOs.Category;
using WebMVC.Application.DTOs.Ingredient;
using WebMVC.Application.DTOs.Instruction;

namespace WebMVC.Application.DTOs.Recipe
{
    public class CreateRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public int PrepTimeMinutes { get; set; }
        public int CookTimeMinutes { get; set; }
        public int Servings { get; set; }
    }
}
