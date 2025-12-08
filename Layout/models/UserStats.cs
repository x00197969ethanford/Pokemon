using System.ComponentModel.DataAnnotations;

namespace pokemon_project.Models
{
    public class UserStats
    {
        public int HeightFeet { get; set; }
        public int HeightInches { get; set; }
        public double WeightKg { get; set; }
    }
}
