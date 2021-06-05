using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyMeals.Data
{
    public class DemoRepo
    {
        private readonly WeeklyMealsContext _context;
        public DemoRepo(WeeklyMealsContext context)
        {
            _context = context;
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
