using System.ComponentModel.DataAnnotations;

namespace SRwebMVC.Models.ViewModels
{
    public class RecipeCreateStep1ViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Prep Time (minutes)")]
        public int PrepTime { get; set; }

        [Display(Name = "Cook Time (minutes)")]
        public int CookTime { get; set; }
    }
}