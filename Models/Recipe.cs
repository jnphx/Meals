using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyMeals.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "# Servings")]
        public int NumberServings { get; set; }

        public int GrainServingsMissing { get; set; }
        public int VegServingsMissing { get; set; }
        public double PercentForYou { get; set; }

        //[Required]
        public ICollection<Ingredient> Ingredients { get; set; }

        //[Required]
        public ICollection<Step> Steps { get; set; }

        public ICollection<MealPlanRecipe> MealPlanRecipes { get; set; }

        public Recipe()
        {
            PercentForYou = 1;
        }

    }
}
