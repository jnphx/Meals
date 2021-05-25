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
        
        public List<FoodsGroup> FoodsGroups { get; set; }

        public async Task OnGetAsync()
        {
            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();
            //.Where(m => m.MealPlanID == userSettings.MealPlanID) - TODO - add back in when done testing
            FoodsGroups = await _context.MealPlans
                .SelectMany(x => x.MealPlanRecipes)
                .SelectMany(y => y.Recipe.Ingredients)
                .OrderBy(x => x.Food.GroceryAisle.Name)
                .ThenBy(x => x.Food.Name)
                .GroupBy(x => new {Aisle = x.Food.GroceryAisle.Name, Food = x.Food.Name, MsType = x.SizeType.Name})
                .Select(x => new FoodsGroup { AisleName = x.Key.Aisle, FoodName = x.Key.Food, AmountType = x.Key.MsType, TotalAmount = x.Sum(y => y.Size)})
                .ToListAsync();
        }
    }
}
