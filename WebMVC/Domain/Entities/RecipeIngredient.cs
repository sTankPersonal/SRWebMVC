using WebMVC.Domain.ValueObjects;

namespace WebMVC.Domain.Entities
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
        public Measurement Measurement { get; set; } = null!;
    }
}
