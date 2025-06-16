using SRwebMVC.Entities;

namespace SRwebMVC.Entities
{
    public class RecipeCategory
    {
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
