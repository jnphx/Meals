using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyMeals.Models;

namespace WeeklyMeals.Data
{
    public class DemoRepo
    {
        private readonly WeeklyMealsContext _context;
      
        public DemoRepo(WeeklyMealsContext context)
        {
            _context = context;
        }

        public double GetNumberMeals()
        {
            //Use linq to sum MealPlanRecipes.NumServings * MealPlanRecipes.PercentForMe
            var mealPlanServings = (from m in _context.MealPlans
                                    join mpr in _context.MealPlanRecipes on m.MealPlanID equals mpr.MealPlanID
                                    join r in _context.Recipes on mpr.RecipeID equals r.RecipeID
                                    join u in _context.UserSettings on m.MealPlanID equals u.MealPlanID
                                    select new
                                    {
                                        r.NumberServings,
                                        mpr.NumberBatches,
                                        mpr.PercentForYou
                                    }).ToList();

            return mealPlanServings.Select(g => g.NumberBatches * g.NumberServings * g.PercentForYou).Sum();
        }

        public void CheckDelete(int MealPlanRecipeID)
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
                    _context.Update(mpr);
                    _context.SaveChanges();
                }
            }
        }

        public List<string> GetDemoList()
        {
            List<string> lstString = new List<string>
            {
                "Val cat",
                "Val camel",
                "Val bird"
            };

            return lstString;
        }
    }
}
