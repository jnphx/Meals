using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.MealPlans
{
    public class IndexModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public IndexModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlan { get;set; }

        public async Task OnGetAsync()
        {
            MealPlan = await _context.MealPlans.ToListAsync();
        }
    }
}
