using System.ComponentModel.DataAnnotations;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.ValueObjects
{
    public class Measurement
    {
        public string Amount { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public required Unit Unit { get; set; }
    }
}
