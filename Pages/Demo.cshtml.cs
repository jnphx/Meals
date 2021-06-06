using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeeklyMeals.Data;

namespace WeeklyMeals.Pages
{
    public class DemoModel : PageModel
    {
        private readonly WeeklyMealsContext _context;
        public string Message { get; set; } = "Initial Request";

        public DemoModel(WeeklyMealsContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        //Handlers
        public void OnPostView(int id)
        {
            Message = $"View handler fired for {id}";
        }
        //Handlers

        public JsonResult OnGetList()
        {
            var repo = new DemoRepo(_context);

            List<string> lstString;

            lstString = repo.GetDemoList();
                        
            return new JsonResult(lstString);
        }

        public JsonResult OnGetList2()
        {
            List<string> lstString = new List<string>
            {
                "Val from List2",
                "Val Radar",
                "Val Jedi"
            };

            return new JsonResult(lstString);
        }

        public IActionResult OnPostFarfy()
        {
            List<string> lstString = new List<string>
            {
                "Val Pl",
                "Val oo",
                "Val py"
            };
            return new JsonResult(lstString);
        }
    }
}
