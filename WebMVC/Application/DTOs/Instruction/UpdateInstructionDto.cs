namespace WebMVC.Application.DTOs.Instruction
{
    public class UpdateInstructionDto
    {
        public int StepNumber { get; set; }
        public string Instructions { get; set; } = string.Empty;
    }
}
