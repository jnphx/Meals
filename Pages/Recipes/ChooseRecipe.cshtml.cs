using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.Recipes
{
    public class ChooseRecipeModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public ChooseRecipeModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipes { get;set; }

        public async Task OnGetAsync()
        {
            Recipes = await _context.Recipes.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int RecipeID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();

            MealPlanRecipe mpr = new MealPlanRecipe();
            mpr.MealPlanID = userSettings.MealPlanID;
            mpr.RecipeID = RecipeID;
            _context.MealPlanRecipes.Add(mpr);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
