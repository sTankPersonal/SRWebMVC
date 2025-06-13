public class RecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public List<RecipeIngredientDto> Ingredients { get; set; } = new();
    public List<RecipeCategoryDto> Categories { get; set; } = new();
    public List<RecipeStepDto> Steps { get; set; } = new();
}