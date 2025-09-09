namespace WebMVC.Application.DTOs.Instruction
{
    public class CreateInstructionDto
    {
        public int StepNumber { get; set; }
        public string Instructions { get; set; } = string.Empty;
    }
}
