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
    public class DeleteModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public DeleteModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MealPlan MealPlan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MealPlan = await _context.MealPlans.FirstOrDefaultAsync(m => m.MealPlanID == id);

            if (MealPlan == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MealPlan = await _context.MealPlans.FindAsync(id);

            if (MealPlan != null)
            {
                _context.MealPlans.Remove(MealPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
