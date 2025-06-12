using System.ComponentModel.DataAnnotations;

namespace SRwebMVC.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the ingredient.")]
        public required string Name { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new();
    }
}
