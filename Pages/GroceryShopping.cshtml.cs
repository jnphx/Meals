using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

            var groceryList = from m in _context.MealPlans
                              join mpr in _context.MealPlanRecipes on m.MealPlanID equals mpr.MealPlanID
                              join r in _context.Recipes on mpr.RecipeID equals r.RecipeID
                              join i in _context.Ingredients on r.RecipeID equals i.Recipe.RecipeID
                              where m.MealPlanID == userSettings.MealPlanID
                              group new { i, mpr } by new
                              {
                                  AisleName = i.Food.GroceryAisle.Name,
                                  FoodName = i.Food.Name,
                                  AmountType = i.SizeType.Name,
                              } into g
                              select new FoodsGroup
                              {
                                  AisleName = g.Key.AisleName,
                                  FoodName = g.Key.FoodName,
                                  AmountType = g.Key.AmountType,
                                  TotalAmount = g.Sum(z => z.i.Size * z.mpr.NumberBatches)
                              } into fg
                              orderby fg.AisleName, fg.FoodName
                              select fg;

            FoodsGroups = groceryList.ToList();
        }
    }
}
