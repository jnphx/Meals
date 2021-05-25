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

        //Session[“UserName”] = UserNameTextBox.Text;
        public async Task OnGetAsync()
        {
            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();
            //.Where(m => m.MealPlanID == userSettings.MealPlanID)
            FoodsGroups = await _context.MealPlans
                .SelectMany(x => x.MealPlanRecipes)
                .SelectMany(y => y.Recipe.Ingredients)
                .OrderBy(x => x.Food.GroceryAisle.Name)
                .ThenBy(x => x.Food.Name)
                .GroupBy(x => new {Aisle = x.Food.GroceryAisle.Name, Food = x.Food.Name, MsType = x.SizeType.Name})
                .Select(x => new FoodsGroup { AisleName = x.Key.Aisle, FoodName = x.Key.Food, AmountType = x.Key.MsType, TotalAmount = x.Sum(y => y.Size)})
                //.GroupBy(p => p.Food.Name, (key, grp) => new { fd = key, SumAmount = grp.ToList() }
                .ToListAsync();
            //.SelectMany(g => 
            //    //AisleName = g.Food.GroceryAisle.Name,
            //    new FoodsGroup {
            //        AisleName = g.Food.GroceryAisle.Name,
            //        FoodName = g.Food.Name,
            //        TotalAmount = g.Size,
            //        AmountType = g.SizeType.Name
            //})
            //.OrderBy(a => a.AisleName)
            //.ThenBy(b => b.FoodName)
            //.ToListAsync();

            //foreach (var line in data.GroupBy(info => info.metric)
            //             .Select(group => new {
            //                 Metric = group.Key,
            //                 Count = group.Count()
            //             })
            //             .OrderBy(x => x.Metric))

            //            .ToList()
            //.GroupBy(b => b.ShortCode)
            //.SelectMany(grouping => grouping.OrderBy(b => b.UploadDate))
            //.ToList()

                // listStudents.GroupBy(g => g.Name).OrderBy(g => g.Key)
                // .SelectMany(g => g.OrderByDescending(x => x.Grade))
                // .ToList()
                // .ForEach(x => Console.WriteLine(x.ToString()));
        }

        //var query = checks.GroupBy<Customer, string>(delegate (Customer c) {
        //    return string.Format("{0} - {1}", c.CustomerId, c.CustomerName);
        //}).Select(delegate (IGrouping<string, Customer> customerGroups) {
        //    return new { Customer = customerGroups.Key, Payments = customerGroups };
        //});

        //var aisles = await _context.MealPlans
        //    .SelectMany(x => x.MealPlanRecipes)
        //    .SelectMany(y => y.Recipe.Ingredients)
        //     .Select(g => new FoodsGroup
        //     {
        //         AisleName = g.Food.GroceryAisle.Name,
        //         FoodName = g.Food.Name,
        //         TotalAmount = g.Size,
        //         AmountType = g.SizeType.Name
        //     })
        //     .ToListAsync();

        //var groups = from GroceryAisle in aisles group aisles by GroceryAisle into newGroceryAisle select newGroceryAisle;


    }
}
