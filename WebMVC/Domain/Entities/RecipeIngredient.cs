namespace WebMVC.Domain.Entities
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public required Ingredient Ingredient { get; set; }

        public decimal Amount { get; set; }
        public int QuantityId { get; set; }
        public required Quantity Quantity { get; set; }
               
    }
}
