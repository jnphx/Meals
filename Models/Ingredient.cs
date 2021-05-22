using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeklyMeals.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        [Required]
        public int FoodID { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public double SizeType { get; set; }

        [Required]
        public double PrepTypeID { get; set; }

        //foreign key to Recipe
        //public int RecipeID;
        public Food Food { get; set; }
    }
}
