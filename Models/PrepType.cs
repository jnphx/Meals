using System.ComponentModel.DataAnnotations;

namespace WeeklyMeals.Models
{
    public class PrepType
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
