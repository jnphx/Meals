using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeeklyMeals.Models;

namespace WeeklyMeals.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly WeeklyMeals.Data.WeeklyMealsContext _context;

        public CreateModel(WeeklyMeals.Data.WeeklyMealsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string chosenFile = Request.Form["ImageURL"];
            if (chosenFile == "")
            {
                Recipe.ImageUrl = "~/images/norecipe.jpg";
            }
            else
            {
                Recipe.ImageUrl = "~/images/" + chosenFile;
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
