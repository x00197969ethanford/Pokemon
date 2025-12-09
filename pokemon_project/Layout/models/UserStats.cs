using System.ComponentModel.DataAnnotations;

namespace pokemon_project.Models
{
    public class UserStats
    {
        [Required(ErrorMessage = "Height (feet) is required.")]
        [Range(0, 8, ErrorMessage = "Feet must be between 0 and 8.")]
        public int HeightFeet { get; set; }

        [Required(ErrorMessage = "Height (inches) is required.")]
        [Range(0, 11, ErrorMessage = "Inches must be between 1 and 11.")]
        public int HeightInches { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(1, 1000, ErrorMessage = "Weight must be between 1 and 1000 kg.")]
        public double WeightKg { get; set; }
    }
}
