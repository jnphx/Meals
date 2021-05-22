using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyMeals.Models
{
    public class Step
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        //Foreign key to Recipe
        //public int RecipeID { get; set; }
    }
}
