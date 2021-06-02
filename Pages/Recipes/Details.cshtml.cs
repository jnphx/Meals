using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Data;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public DetailsModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.RecipeID == id);
            Recipe = await _context.Recipes
               .Include(s => s.Steps)
               .Include(i => i.Ingredients).ThenInclude(s => s.SizeType)
               .Include(i => i.Ingredients).ThenInclude(s => s.Food)
               .Include(i => i.Ingredients).ThenInclude(s => s.PrepType)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
