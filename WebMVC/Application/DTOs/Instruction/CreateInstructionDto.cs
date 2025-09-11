namespace WebMVC.Application.DTOs.Instruction
{
    public class CreateInstructionDto
    {
        public int recipeId { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
