using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;
using WeeklyMeals.Models.WeeklyMealsViewModels;

namespace WeeklyMeals.Pages.Recipes
{
    public class ChooseRecipeModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public ChooseRecipeModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IList<ChooseMeal> Recipes { get; set; }

        public async Task OnGetAsync()
        {
            //Get all recipes joined with MealPlanRecipes, outer join
            //If match, then show +/- batch buttons, if not match, show add button
            var mprRecipes = from m in _context.MealPlanRecipes
                             join u in _context.UserSettings on m.MealPlanID equals u.MealPlanID
                             select m;

            IQueryable<ChooseMeal> choosemealrecipes = from r in _context.Recipes
                                                       join mpr in mprRecipes on r.RecipeID equals mpr.RecipeID
                                                       into MPRGroup
                                                       from mpr in MPRGroup.DefaultIfEmpty()
                                                       select new ChooseMeal
                                                       {
                                                           RecipeID = r.RecipeID,
                                                           RecipeName = r.Name,
                                                           ImageUrl = r.ImageUrl,
                                                           MealPlanRecipeID = mpr == null ? 0 : mpr.MealPlanRecipeID,
                                                           NumberBatches = mpr == null ? 0 : mpr.NumberBatches
                                                       };

            Recipes = await choosemealrecipes.ToListAsync();

            //Recipes = await _context.Recipes.ToListAsync();
        }

        public async Task<IActionResult> OnPostCheckDelete(int? MealPlanRecipeID)
        {
            MealPlanRecipe mpr = _context.MealPlanRecipes.Find(MealPlanRecipeID);

            if (mpr != null)
            {
                if (mpr.NumberBatches == 1)
                {
                    //They want to delete this
                    _context.MealPlanRecipes.Remove(mpr);
                    _context.SaveChanges();
                }
                else
                {
                    //Decrement batch count
                    --mpr.NumberBatches;
                    if (await TryUpdateModelAsync<MealPlanRecipe>(
                        mpr,
                        "",
                        s => s.NumberBatches))
                    {
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToPage("/Recipes/ChooseRecipe");
        }

        public async Task<IActionResult> OnPostCheckAdd(int? MealPlanRecipeID)
        {
            MealPlanRecipe mpr = _context.MealPlanRecipes.Find(MealPlanRecipeID);

            if (mpr != null)
            {
                //Increment batch count
                ++mpr.NumberBatches;
                if (await TryUpdateModelAsync<MealPlanRecipe>(
                    mpr,
                    "",
                    s => s.NumberBatches))
                {
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("/Recipes/ChooseRecipe");
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

            return RedirectToPage("/Index");
        }
    }
}
