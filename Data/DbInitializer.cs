using System.Linq;
using WeeklyMeals.Models;

namespace WeeklyMeals.Data
{
    public class DbInitializer
    {
        public static void Initialize(WeeklyMealsContext context)
        {
            // Look for any students.
            if (context.MealPlans.Any())
            {
                return;   // DB has been seeded
            }

            var steps = new Step[]
            {
                new Step { Name = "Bring pot small pot of water to a boil, add lentils, boil at med-hi for 10 min, then drain" },
                new Step { Name = "Saute onion and mushrooms 5 mins" },

            };

            var cup = new SizeType { Name = "cup" };
            var clove = new SizeType { Name = "clove" };
            var tsp = new SizeType { Name = "tsp" };

            var sizeTypes = new SizeType[]
            {
                cup,
                new SizeType { Name = "TB" },
                tsp,
                new SizeType { Name = "ou" },
                new SizeType { Name = "lb" },
                new SizeType { Name = "can" },
                new SizeType { Name = "each" },
                clove
            };
            context.SizeTypes.AddRange(sizeTypes);
            context.SaveChanges();

            var chop = new PrepType { Name = "Chop" };
            var noprep = new PrepType { Name = "No prep" };

            var prepTypes = new PrepType[]
            {
                noprep,
                chop,
                new PrepType { Name = "Cook grains" },
                new PrepType { Name = "Cook beans" },
                new PrepType { Name = "Make sauce" }
            };
            context.PrepTypes.AddRange(prepTypes);
            context.SaveChanges();

            var grainsBeans = new GroceryAisle { Name = "Grains/Beans" };
            var produce = new GroceryAisle { Name = "Produce" };
            var spices = new GroceryAisle { Name = "Spices" };
            var canned = new GroceryAisle { Name = "Canned goods" };

            var groceryAisles = new GroceryAisle[]
            {
                produce,
                grainsBeans,
                new GroceryAisle { Name = "Condiments" },
                new GroceryAisle { Name = "Plant milk" },
                new GroceryAisle { Name = "Frozen" },
                canned,
                spices
            };
            context.GroceryAisles.AddRange(groceryAisles);
            context.SaveChanges();

            var lentils = new Food { Name = "Lentils", GroceryAisle = grainsBeans, CookedCupsConversion = 2.5 };
            var basmati = new Food { Name = "Basmati rice", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var garlic = new Food { Name = "Garlic", GroceryAisle = produce };
            var onions = new Food { Name = "Onion", GroceryAisle = produce, CookedCupsConversion = 0.3 };
            var stock = new Food { Name = "Vegetable stock", GroceryAisle = canned };
            var cumin = new Food { Name = "Cumin seeds", GroceryAisle = spices };
            var mushrooms = new Food { Name = "Mushrooms", GroceryAisle = produce };

            var foods = new Food[]
            {
                lentils,
                basmati,
                garlic,
                onions,
                mushrooms,
                stock,
                cumin
            };
            context.Foods.AddRange(foods);
            context.SaveChanges();

            var ingredLentils = new Ingredient { Food = lentils, PrepType = noprep, Size = 0.5, SizeType = cup };
            var ingredOnions = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeType = cup };
            var ingredMushrooms = new Ingredient { Food = mushrooms, PrepType = chop, Size = 2, SizeType = cup };
            var ingredGarlic = new Ingredient { Food = garlic, PrepType = chop, Size = 1, SizeType = clove };
            var ingredStock = new Ingredient { Food = stock, PrepType = noprep, Size = 2, SizeType = cup };
            var ingredCumin = new Ingredient { Food = cumin, PrepType = noprep, Size = .5, SizeType = tsp };
            var ingredBasmati = new Ingredient { Food = basmati, PrepType = noprep, Size = 2, SizeType = cup };

            var ingreds = new Ingredient[] {
                ingredLentils,
                ingredOnions,
                ingredGarlic,
                ingredMushrooms,
                ingredStock,
                ingredCumin,
                ingredBasmati
        };

            context.Ingredients.AddRange(ingreds);
            context.SaveChanges();
            /*
            var steps = new Step[]
            {
                new Step { Name = "Bring pot small pot of water to a boil, add lentils, boil at med-hi for 10 min, then drain", RecipeID = 1 },
                new Step { Name = "Saute onion and mushrooms 5 mins", RecipeID = 1 },
                new Step { Name = "Add garlic and cumin seeds 1 min.", RecipeID = 1 },
                new Step { Name = "Add lentils, rice, veg stock, bring to a boil, then simmer covered 15 min.", RecipeID = 1 }
            };*/
            //context.Steps.AddRange(steps);
            //context.SaveChanges();

            //    var mealPlanRecipes = new MealPlanRecipe[]
            //    {
            //        new MealPlanRecipe{MealPlanID=1,RecipeID=1},
            //        new MealPlanRecipe{MealPlanID=2,RecipeID=2},
            //        new MealPlanRecipe{MealPlanID=2,RecipeID=3},
            //        new MealPlanRecipe{MealPlanID=3,RecipeID=1},
            //        new MealPlanRecipe{MealPlanID=3,RecipeID=2},
            //        new MealPlanRecipe{MealPlanID=3,RecipeID=4},
            //        new MealPlanRecipe{MealPlanID=3,RecipeID=5},
            //    };

            ////var food = new Food { Name = "Lentils", Category="Beans"}

            //context.MealPlanRecipes.AddRange(mealPlanRecipes);
            //    context.SaveChanges();
            //}

            var recipes = new Recipe[]
            {
                new Recipe{Name="Lentils & Rice", Steps = steps, Ingredients = ingreds, ImageUrl = "~/images/lentilsandrice.jpg", VolumeInCups = 10},
                new Recipe{Name="Black bean chili", ImageUrl = "~/images/chili.jpg", VolumeInCups = 8},
                //new Recipe{Name="Pinto bean chili"},
                //new Recipe{Name="Peanut stir-fry"},
                new Recipe{Name="French lentils", ImageUrl = "~/images/frenchlentils.jpg", VolumeInCups = 9}
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();

            //var asianRecipes = new Recipe[]
            //{
            //    new Recipe{Name="Pinto bean chili"},
            //    new Recipe{Name="Peanut stir-fry"}
            //};

            var mealPlans = new MealPlan[]
                {
                new MealPlan{Name="The Usual"},
                new MealPlan{Name="Mexican"},
                new MealPlan{Name="Asian"},
                };

            context.MealPlans.AddRange(mealPlans);
            context.SaveChanges();

            var mealPlanRecipes = new MealPlanRecipe[]
            {
                new MealPlanRecipe{RecipeID=1,MealPlanID=1,NumberBatches=2},
                new MealPlanRecipe{RecipeID=1,MealPlanID=2},
                new MealPlanRecipe{RecipeID=1,MealPlanID=3},
                new MealPlanRecipe{RecipeID=2,MealPlanID=2},
                new MealPlanRecipe{RecipeID=2,MealPlanID=3,NumberBatches=2},
                new MealPlanRecipe{RecipeID=3,MealPlanID=3},
                new MealPlanRecipe{RecipeID=3,MealPlanID=1,NumberBatches=3},
                new MealPlanRecipe{RecipeID=3,MealPlanID=2}
            };

            context.MealPlanRecipes.AddRange(mealPlanRecipes);
            context.SaveChanges();

            var userSettings = new UserSettings[]
            {
                new UserSettings{MealPlanID=1 }
            };

            context.UserSettings.AddRange(userSettings);
            context.SaveChanges();
        }
    }
}
