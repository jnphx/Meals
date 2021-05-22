using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyMeals.Models
{
    public class Food
    {
        public int FoodID { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required] TODO: should foreign keys be required?
        //Foreign key to GroceryAisle
        public int GroceryAisleID { get; set; }

        public GroceryAisle GroceryAisle { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
