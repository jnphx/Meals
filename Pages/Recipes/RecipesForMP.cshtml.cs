using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.Recipes
{
    public class RecipesForMPModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public RecipesForMPModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlans { get; set; }
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int SelectedMealPlanId { get; set; }
        public MealPlanRecipe MealPlanRecipe { get; set; }

        public async Task OnGetAsync(int SelectedMealPlanId)
        {
            IQueryable<MealPlan> RecipesIQ = _context.MealPlans
                     .Include(e => e.MealPlanRecipes)
                     .ThenInclude(c => c.Recipe);

            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();

            if (SelectedMealPlanId == 0)
            {
                //First time through, they haven't selected, get from UserSettings
                
                if (userSettings != null)
                {
                    //They have selected a recipe
                    SelectedMealPlanId = userSettings.MealPlanID;
                }
            } else
            {
                //They selected a mealplan from the dropdown, update UserSettings.MealPlanSelection
                
                userSettings.MealPlanID = SelectedMealPlanId;

                if (userSettings != null)
                {
                    if (await TryUpdateModelAsync<UserSettings>(
                        userSettings,
                        "",
                        s => s.MealPlanID))
                    {
                        await _context.SaveChangesAsync();
                        //return RedirectToPage("./Index");
                    }
                }
            }

            //Filter for the selected meal plan id
            RecipesIQ = RecipesIQ.Where(mp => mp.MealPlanID == SelectedMealPlanId);

            MealPlans = await RecipesIQ.AsNoTracking().ToListAsync();

            using (var context = _context)
            {
                Options = context.MealPlans.Select(a =>
                                            new SelectListItem
                                            {
                                                Value = a.MealPlanID.ToString(),
                                                Text = a.Name
                                            }).ToList();

            }
        }

        public async Task<IActionResult> OnPostAsync(int? MealPlanRecipeID)
        {
            if (MealPlanRecipeID == null)
            {
                return NotFound();
            }

            MealPlanRecipe = await _context.MealPlanRecipes.FindAsync(MealPlanRecipeID);

            if (MealPlanRecipe != null)
            {
                _context.MealPlanRecipes.Remove(MealPlanRecipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./RecipesForMP");
        }
    }
}
