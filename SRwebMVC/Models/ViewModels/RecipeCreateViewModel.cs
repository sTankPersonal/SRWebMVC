using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SRwebMVC.Models.DTOs;

namespace SRwebMVC.Models.ViewModels
{
    public class RecipeCreateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Prep Time (minutes)")]
        public int PrepTime { get; set; }

        [Display(Name = "Cook Time (minutes)")]
        public int CookTime { get; set; }

        // Current selections
        public List<RecipeCategoryDto> Categories { get; set; } = new();
        public List<RecipeIngredientDto> Ingredients { get; set; } = new();
        public List<RecipeStepDto> Steps { get; set; } = new();

        // For adding new items
        //public int NewCategoryId { get; set; }
        //public int NewIngredientId { get; set; }
        //public decimal NewIngredientAmount { get; set; }
        //public int NewIngredientQuantityId { get; set; }
        //public string NewStepDescription { get; set; } = string.Empty;
    }
}