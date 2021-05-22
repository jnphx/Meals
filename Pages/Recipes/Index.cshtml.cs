using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public IndexModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipes { get;set; }

        public async Task OnGetAsync()
        {
            Recipes = await _context.Recipes.ToListAsync();
        }
    }
}
