using System.ComponentModel.DataAnnotations;

namespace SRwebMVC.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the recipe.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please enter a set of instructions for the recipe.")]
        public required string Instructions { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new();
        public List<RecipeCategory> RecipeCategories{ get; set; } = new();
    }
}
