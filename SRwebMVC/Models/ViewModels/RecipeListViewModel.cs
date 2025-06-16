using System.Collections.Generic;
using SRwebMVC.Models.DTOs;

namespace SRwebMVC.Models.ViewModels
{
    public class RecipeListViewModel
    {
        public List<RecipeDto> Recipes { get; set; } = new();
        public string? SearchName { get; set; }
        public string? SearchIngredient { get; set; }
        public string? SearchCategory { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
    }
}