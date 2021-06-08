﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Data;
using WeeklyMeals.Models;
using WeeklyMeals.Models.WeeklyMealsViewModels;

namespace WeeklyMeals.Pages.Recipes
{
    public class RecipesForMPModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;
        public string Message { get; set; } = "Initial Request";

        public RecipesForMPModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlans { get; set; }
        public MealPlan MealPlan { get; set; }
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int SelectedMealPlanId { get; set; }
        public MealPlanRecipe MealPlanRecipe { get; set; }
        public int MealCount;

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
                    //Read from userSettings
                    SelectedMealPlanId = userSettings.MealPlanID;
                }
            }
            else
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
                    }
                }
            }

            //Filter for the selected meal plan id
            //RecipesIQ = RecipesIQ.FirstOrDefault(mp => mp.MealPlanID == SelectedMealPlanId);

            MealPlan = RecipesIQ.FirstOrDefault(mp => mp.MealPlanID == SelectedMealPlanId);

            MealPlans = await RecipesIQ.AsNoTracking().ToListAsync();

            //Update the options for mealplan select list
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

        //When removing a recipe from the meal plan list
        public async Task<IActionResult> OnPostDeleteAsync(int? MealPlanRecipeID)
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

        public void OnPostCheckDeleteAjax()
        {
            int MealPlanRecipeID = 4;
            MealPlanRecipe mpr = _context.MealPlanRecipes.Find(MealPlanRecipeID);
            var repo = new DemoRepo(_context);
            repo.CheckDelete(MealPlanRecipeID);
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

            return RedirectToPage("./RecipesForMP");
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

            return RedirectToPage("./RecipesForMP");
        }
    }
}
