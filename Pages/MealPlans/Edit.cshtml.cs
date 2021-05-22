using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Data;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.MealPlans
{
    public class EditModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public EditModel(WeeklyMeals.Data.WeeklyMealsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MealPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealPlanExists(MealPlan.MealPlanID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MealPlanExists(int id)
        {
            return _context.MealPlans.Any(e => e.MealPlanID == id);
        }
    }
}
