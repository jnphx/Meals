using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models.WeeklyMealsViewModels;

namespace WeeklyMeals.Pages.MealPlans
{
    public class WeekendPrepModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;
      
        public WeekendPrepModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public List<FoodsGroup> FoodsGroups { get; set; }

        public async Task OnGetAsync()
        {
            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();
            FoodsGroups = await _context.MealPlans
                .Where(m => m.MealPlanID == userSettings.MealPlanID)
                .SelectMany(x => x.MealPlanRecipes)
                .SelectMany(y => y.Recipe.Ingredients)
                .Where(z => z.PrepTypeID != 0 && !z.PrepType.Name.Equals("No prep"))
                .OrderBy(x => x.Food.GroceryAisle.Name)
                .ThenBy(x => x.Food.Name)
                .GroupBy(x => new { Aisle = x.Food.GroceryAisle.Name, Food = x.Food.Name, MsType = x.SizeType.Name, Prep = x.PrepType.Name })
                .Select(x => new FoodsGroup { AisleName = x.Key.Aisle, FoodName = x.Key.Food, AmountType = x.Key.MsType, TotalAmount = x.Sum(y => y.Size), PrepType = x.Key.Prep })
                .ToListAsync();

        }
    }
}
