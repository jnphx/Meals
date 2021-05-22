using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;
using WeeklyMeals.Models.WeeklyMealsViewModels;

namespace WeeklyMeals.Pages
{
    public class GroceryShoppingModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public GroceryShoppingModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }
        
        public List<MealPlan> MealPlans { get; set; }
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int SelectedMealPlanId { get; set; }

        //Session[“UserName”] = UserNameTextBox.Text;
        public async Task OnGetAsync(int SelectedMealPlanId)
        {
            IQueryable<MealPlan> MealPlansIQ = _context.MealPlans
                .Include(mpr => mpr.MealPlanRecipes)
                    .ThenInclude(mealplan => mealplan.Recipe)
                        .ThenInclude(recipe => recipe.Ingredients)
                            .ThenInclude(ingredient => ingredient.Food)
                                .ThenInclude(ingFood => ingFood.GroceryAisle);

            if (SelectedMealPlanId != 0) {
                MealPlansIQ = MealPlansIQ.Where(mp => mp.MealPlanID == SelectedMealPlanId);
            }

            MealPlans = await MealPlansIQ.AsNoTracking().ToListAsync();

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
