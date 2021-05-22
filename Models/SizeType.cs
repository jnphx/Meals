using System.ComponentModel.DataAnnotations;

namespace WeeklyMeals.Models
{
    public class SizeType
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
