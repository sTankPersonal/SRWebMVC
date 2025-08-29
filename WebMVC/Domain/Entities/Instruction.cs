using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMVC.Domain.Entities
{
    public class Instruction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public Recipe Recipe { get; set; } = null!;

        [Required]
        public int StepNumber { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}