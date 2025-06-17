namespace SRwebMVC.Models.DTOs
{
    public class EditRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
    }
}
