namespace WebMVC.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PrepTimeMinutes { get; set; } = 0;
        public int CookTimeMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
        public ICollection<RecipeCategory> RecipeCategories{ get; set; } = [];
        public ICollection<Instruction> Instructions { get; set; } = [];
    }
}