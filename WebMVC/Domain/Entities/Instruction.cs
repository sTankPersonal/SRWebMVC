namespace WebMVC.Domain.Entities
{
    public class Instruction
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }

        public int StepNumber { get; set; }
        public string Instructions { get; set; } = string.Empty;
    }
}
