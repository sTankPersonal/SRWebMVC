namespace WebMVC.Domain.ValueObjects
{
    public class RecipeStep
    {
        public int StepNumber { get; set; }
        public string StepInstructions { get; set; } = string.Empty;
    }
}
