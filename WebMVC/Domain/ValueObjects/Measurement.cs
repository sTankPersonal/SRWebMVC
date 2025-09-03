using System.ComponentModel.DataAnnotations;
using WebMVC.Domain.Entities;

namespace WebMVC.Domain.ValueObjects
{
    public class Measurement
    {
        [Required(ErrorMessage = "Please enter an amount for the Measurement")]
        public required string Amount { get; set; }

        public int UnitId { get; set; }
        [Required(ErrorMessage = "Please select a unit for the Measurement")]
        public required Unit Unit { get; set; }
    }
}
