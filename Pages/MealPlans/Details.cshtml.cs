using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Data;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.MealPlans
{
    public class DetailsModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public DetailsModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public MealPlan MealPlan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //MealPlan = await _context.MealPlan.FirstOrDefaultAsync(m => m.MealPlanID == id);
            MealPlan = await _context.MealPlans
                .Include(mpr => mpr.MealPlanRecipes)
              .ThenInclude(r => r.Recipe)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.MealPlanID == id);

            if (MealPlan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
