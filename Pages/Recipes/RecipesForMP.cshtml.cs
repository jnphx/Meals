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
        public UserSettings userSettings;
        [BindProperty]
        public int SelectedMealPlanId { get; set; }

        //public async Task OnGetAsync(int SelectedMealPlanId)
        //{
        //    IQueryable<MealPlan> MealPlansIQ = _context.MealPlans
        //            .Include(mealplan => mealplan.Recipes)
        //                .ThenInclude(recipe => recipe.Ingredients)
        //                    .ThenInclude(ingredient => ingredient.Food)
        //                        .ThenInclude(ingFood => ingFood.GroceryAisle);

        //    if (SelectedMealPlanId != 0)
        //    {
        //        MealPlansIQ = MealPlansIQ.Where(mp => mp.MealPlanID == SelectedMealPlanId);
        //    }
        //    Recipes = await _context.Recipes.ToListAsync();
        //}

        public async Task OnGetAsync(int SelectedMealPlanId)
        {
            IQueryable<MealPlan> RecipesIQ = _context.MealPlans
                    .Include(e => e.MealPlanRecipes)
                    .ThenInclude(c => c.Recipe);

            if (SelectedMealPlanId == 0)
            {
                //First time through, they haven't selected.
                var selectedPlan = _context.UserSettings.FirstOrDefault(x => x.MealPlanSelection > 0);
                if (selectedPlan != null)
                {
                    //They have selected a recipe
                    SelectedMealPlanId = selectedPlan.MealPlanSelection;
                }
                else
                {
                    var defaultPlan = RecipesIQ.FirstOrDefault();
                    if (defaultPlan != null)
                    {
                        SelectedMealPlanId = defaultPlan.MealPlanID;
                    }
                }
            } else
            {
                //They selected a mealplan from the dropdown, update UserSettings.MealPlanSelection
                
                var mealPlanToUpdate = await _context.UserSettings.FirstOrDefaultAsync();
                mealPlanToUpdate.MealPlanSelection = SelectedMealPlanId;

                if (mealPlanToUpdate != null)
                {
                    if (await TryUpdateModelAsync<UserSettings>(
                        mealPlanToUpdate,
                        "",
                        s => s.MealPlanSelection))
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
    }
}
