using System.ComponentModel.DataAnnotations;

namespace WebMVC.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the category.")]
        public required string Name { get; set; }
        public List<RecipeCategory> RecipeCategories { get; set; } = new();

    }
}
