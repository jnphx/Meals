using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.MealPlans
{
    public class WeekendPrepModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;
      
        public WeekendPrepModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlans { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<MealPlan> MealPlansIQ = _context.MealPlans
                .Include(mpr => mpr.MealPlanRecipes)
                    .ThenInclude(mealplan => mealplan.Recipe)
                        .ThenInclude(recipe => recipe.Ingredients)
                            .ThenInclude(ingredient => ingredient.Food)
                                .ThenInclude(ingFood => ingFood.GroceryAisle);

            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();

            //Filter for the selected meal plan id
            MealPlansIQ = MealPlansIQ.Where(mp => mp.MealPlanID == userSettings.MealPlanID);

            MealPlans = await MealPlansIQ.AsNoTracking().ToListAsync();

        }
    }
}
