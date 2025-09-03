using WebMVC.Domain.ValueObjects;

namespace WebMVC.Domain.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Measurement> Measurements { get; set; } = [];
    }
}