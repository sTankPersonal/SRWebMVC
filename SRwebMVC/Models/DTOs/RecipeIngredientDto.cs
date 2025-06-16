namespace SRwebMVC.Models.DTOs
{
    public class RecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = String.Empty;
        public decimal Amount { get; set; }
        public int QuantityId { get; set; }
        public string QuantityName { get; set; } = String.Empty;
    }
}