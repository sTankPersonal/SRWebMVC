using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SRwebMVC.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the recipe.")]
        public required string Name { get; set; }
        public int PrepTime { get; set; } //(Minutes)
        public int CookTime { get; set; } //(Minutes)
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new();
        public List<RecipeCategory> RecipeCategories{ get; set; } = new();
        public List<RecipeStep> Steps { get; set; } = new();
    }
}
