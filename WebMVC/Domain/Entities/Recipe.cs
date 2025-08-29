using System.ComponentModel.DataAnnotations;

namespace WebMVC.Domain.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the recipe.")]
        public required string Name { get; set; }
        public int PrepTime { get; set; } //(Minutes)
        public int CookTime { get; set; } //(Minutes)
        public int Servings { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
        public List<RecipeCategory> RecipeCategories{ get; set; } = [];
        public List<Instruction> Instructions { get; set; } = [];
    }
}
