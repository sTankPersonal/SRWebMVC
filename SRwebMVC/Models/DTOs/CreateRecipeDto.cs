namespace SRwebMVC.Models.DTOs
{
    public class CreateRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        //public List<RecipeStepDto> Steps { get; set; } = new();
    }
}
