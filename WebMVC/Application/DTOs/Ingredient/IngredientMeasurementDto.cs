using WebMVC.Application.DTOs.Unit;

namespace WebMVC.Application.DTOs.Ingredient
{
    public class IngredientMeasurementDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public required UnitDto Unit { get; set; }
    }
}
