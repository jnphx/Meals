using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeeklyMeals.Data;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.MealPlans
{
    public class AddToPlanModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public AddToPlanModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MealPlan MealPlan { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MealPlans.Add(MealPlan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
