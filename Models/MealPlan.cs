using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeeklyMeals.Models
{
    public class MealPlan
    {
        public int MealPlanID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<MealPlanRecipe> MealPlanRecipes { get; set; }
    }
}
