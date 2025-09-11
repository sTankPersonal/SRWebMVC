namespace WebMVC.Application.DTOs.Instruction
{
    public class InstructionDto
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
