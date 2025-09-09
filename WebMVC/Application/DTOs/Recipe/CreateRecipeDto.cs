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
        public ICollection<IngredientMeasurementDto> Ingredients { get; set; } = [];
        public ICollection<CategoryDto> Categories { get; set; } = [];
        public ICollection<InstructionDto> Instructions { get; set; } = [];
    }
}
