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

        //Session[“UserName”] = UserNameTextBox.Text;
        public async Task OnGetAsync()
        {
            IQueryable<MealPlan> MealPlansIQ = _context.MealPlans
                .Include(mpr => mpr.MealPlanRecipes)
                    .ThenInclude(mealplan => mealplan.Recipe)
                        .ThenInclude(recipe => recipe.Ingredients)
                            .ThenInclude(ingredient => ingredient.Food)
                                .ThenInclude(ingFood => ingFood.GroceryAisle);

            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();

            MealPlansIQ = MealPlansIQ.Where(mp => mp.MealPlanID == userSettings.MealPlanID);

            MealPlans = await MealPlansIQ.AsNoTracking().ToListAsync();
        }
    }
}
