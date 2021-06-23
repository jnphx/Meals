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
            var bag = new SizeType { Name = "bag" };
            var can = new SizeType { Name = "can" };
            var each = new SizeType { Name = "each" };

            var sizeTypes = new SizeType[]
            {
                cup,
                new SizeType { Name = "TB" },
                tsp,
                new SizeType { Name = "ou" },
                new SizeType { Name = "lb" },
                clove,
                bag,
                can,
                each
            };
            context.SizeTypes.AddRange(sizeTypes);
            context.SaveChanges();

            var chop = new PrepType { Name = "chop" };
            var noprep = new PrepType { Name = "No prep" };
            var steam = new PrepType { Name = "steam" };
            var precook = new PrepType { Name = "cook grains" };
            var drain = new PrepType { Name = "drain and rinse" };

            var prepTypes = new PrepType[]
            {
                noprep,
                chop,
                steam,
                precook,
                new PrepType { Name = "cook beans" },
                new PrepType { Name = "make sauce" }
            };
            context.PrepTypes.AddRange(prepTypes);
            context.SaveChanges();

            var grainsBeans = new GroceryAisle { Name = "Grains/Beans" };
            var produce = new GroceryAisle { Name = "Produce" };
            var spices = new GroceryAisle { Name = "Spices" };
            var canned = new GroceryAisle { Name = "Canned goods" };
            var frozen = new GroceryAisle { Name = "Frozen" };

            var groceryAisles = new GroceryAisle[]
            {
                produce,
                grainsBeans,
                new GroceryAisle { Name = "Condiments" },
                new GroceryAisle { Name = "Plant milk" },
                frozen,
                canned,
                spices
            };
            context.GroceryAisles.AddRange(groceryAisles);
            context.SaveChanges();

            var lentils = new Food { Name = "lentils", GroceryAisle = grainsBeans, CookedCupsConversion = 2.5 };
            var basmati = new Food { Name = "basmati rice", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var garlic = new Food { Name = "garlic", GroceryAisle = produce };
            var onions = new Food { Name = "onion", GroceryAisle = produce, CookedCupsConversion = 0.3 };
            var stock = new Food { Name = "vegetable stock", GroceryAisle = canned };
            var cumin = new Food { Name = "cumin seeds", GroceryAisle = spices };
            var mushrooms = new Food { Name = "mushrooms", GroceryAisle = produce };
            //staples
            var frozengreenbeans = new Food { Name = "frozen green beans", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var frozenbroc = new Food { Name = "frozen broccoli", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var biggreens = new Food { Name = "2 lb greens", GroceryAisle = produce, CookedCupsConversion = 8 };
            var broccolibag = new Food { Name = "broccoli", GroceryAisle = produce, CookedCupsConversion = 8 };
            var poundgreens = new Food { Name = "1 lb greens", GroceryAisle = produce, CookedCupsConversion = 6 };
            var frozenPeppers = new Food { Name = "12 oz frozen pepper/onion", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var frozenCauliflower = new Food { Name = "12 oz frozen cauliflower", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var frozenVeg = new Food { Name = "12 oz frozen frozen veg", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var anyGrain = new Food { Name = "grains", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var anyBeans = new Food { Name = "beans", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var frozenPeas = new Food { Name = "12 oz frozen peas", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var canTomatoes = new Food { Name = "16 ou tomatoes", GroceryAisle = canned, CookedCupsConversion = 2 };
            var canBlackBeans = new Food { Name = "black beans", GroceryAisle = canned, CookedCupsConversion = 2 };
            var greenPeppers = new Food { Name = "green pepper", GroceryAisle = produce };
            var chiliPowder = new Food { Name = "chili powder", GroceryAisle = spices };
            var curry = new Food { Name = "curry powder", GroceryAisle = spices };
            var coriander = new Food { Name = "coriander", GroceryAisle = spices };

            var foods = new Food[]
            {
                lentils,
                basmati,
                garlic,
                onions,
                mushrooms,
                stock,
                cumin,
                frozengreenbeans,
                frozenbroc,
                biggreens,
                broccolibag,
                poundgreens,
                frozenPeppers,
                canTomatoes,
                canBlackBeans,
                greenPeppers,
                chiliPowder,
                coriander
            };
            context.Foods.AddRange(foods);
            context.SaveChanges();

            var ingredLentils = new Ingredient { Food = lentils, PrepType = noprep, Size = 0.5, SizeType = cup };
            var ingredOnions = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeType = cup };
            var ingredOnions1 = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeType = cup };
            var ingredMushrooms = new Ingredient { Food = mushrooms, PrepType = chop, Size = 2, SizeType = cup };
            var ingredGarlic = new Ingredient { Food = garlic, PrepType = chop, Size = 1, SizeType = clove };
            var ingredStock = new Ingredient { Food = stock, PrepType = noprep, Size = 2, SizeType = cup };
            var ingredCumin = new Ingredient { Food = cumin, PrepType = noprep, Size = .5, SizeType = tsp };
            var ingredBasmati = new Ingredient { Food = basmati, PrepType = noprep, Size = 2, SizeType = cup };
            var ingredBlackBeans = new Ingredient { Food = canBlackBeans, PrepType = noprep, Size = 1, SizeType = can };
            var ingredCanTomatoes = new Ingredient { Food = canTomatoes, PrepType = noprep, Size = 1, SizeType = can };
            var ingredBlackBeans1 = new Ingredient { Food = canBlackBeans, PrepType = noprep, Size = 1, SizeType = can };
            var ingredCanTomatoes1 = new Ingredient { Food = canTomatoes, PrepType = noprep, Size = 1, SizeType = can };
            var ingredCanTomatoes2 = new Ingredient { Food = canTomatoes, PrepType = noprep, Size = 1, SizeType = can };
            var ingredPeppers = new Ingredient { Food = greenPeppers, PrepType = chop, Size = 1, SizeType = each };
            var ingredFrozenPeppers = new Ingredient { Food = frozenPeppers, PrepType = noprep, Size = 1, SizeType = bag };
            var ingredFrozenCauliflower = new Ingredient { Food = frozenCauliflower, PrepType = noprep, Size = 1, SizeType = bag };
            var ingredAnyFrozenVeg = new Ingredient { Food = frozenVeg, PrepType = noprep, Size = 1.5, SizeType = cup };
            var ingredAnyGrain = new Ingredient { Food = anyGrain, PrepType = precook, Size = 1, SizeType = cup };
            var ingredAnyBeans = new Ingredient { Food = anyBeans, PrepType = drain, Size = .5, SizeType = can };
            var ingredFrozenPeas = new Ingredient { Food = frozenPeas, PrepType = noprep, Size = .25, SizeType = cup };
            var ingredChiliCumin = new Ingredient { Food = cumin, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredChilipowder = new Ingredient { Food = chiliPowder, PrepType = noprep, Size = 4, SizeType = tsp };
            var ingredChilipowder1 = new Ingredient { Food = chiliPowder, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredCurry = new Ingredient { Food = curry, PrepType = noprep, Size = 1, SizeType = tsp };
            var ingredCoriander = new Ingredient { Food = coriander, PrepType = noprep, Size = .5, SizeType = tsp };

            var snapIngreds = new Ingredient[]
            {
                ingredCanTomatoes,
                ingredFrozenPeppers,
                ingredBlackBeans,
                ingredChilipowder1
            };

            var snapIndianIngreds = new Ingredient[]
            {
                ingredCanTomatoes2,
                ingredFrozenCauliflower,
                ingredFrozenPeas,
                ingredCurry
            };

            var snapBowlIngreds = new Ingredient[]
            {
                ingredAnyFrozenVeg,
                ingredAnyGrain,
                ingredAnyBeans
            };
/*
            var ingreds = new Ingredient[] {
                ingredLentils,
                ingredOnions,
                ingredGarlic,
                ingredMushrooms,
                ingredStock,
                ingredCumin,
                ingredBasmati,
                ingredBlackBeans,
                ingredChiliCumin,
                ingredCoriander
        };

            context.Ingredients.AddRange(ingreds);
            context.SaveChanges();
*/
            var chiliIngreds = new Ingredient[]
            {
                ingredBlackBeans1,
                ingredCanTomatoes1,
                ingredOnions,
                ingredPeppers,
                ingredChiliCumin,
                ingredChilipowder,
                ingredCoriander
            };
            var lentilRiceIngreds = new Ingredient[] {
                ingredLentils,
                ingredOnions1,
                ingredGarlic,
                ingredMushrooms,
                ingredStock,
                ingredCumin,
                ingredBasmati
            };

            var recipes = new Recipe[]
            {
                new Recipe{Name="Lentils & Rice", Steps = steps, Ingredients = lentilRiceIngreds, ImageUrl = "~/images/lentilsandrice.jpg", NumberServings = 6},
                new Recipe{Name="Black bean chili", Ingredients = chiliIngreds, ImageUrl = "~/images/chili.jpg", NumberServings = 8},
                //new Recipe{Name="Pinto bean chili"},
                //new Recipe{Name="Peanut stir-fry"},
                new Recipe{Name="French lentils", ImageUrl = "~/images/frenchlentils.jpg", NumberServings = 8},
                new Recipe{Name="Quick Mexican", Ingredients= snapIngreds, ImageUrl="~/images/beansrice.jpg", NumberServings=4}, //Ingredients= snapIngreds
                new Recipe{Name="Quick Indian", Ingredients= snapIndianIngreds, ImageUrl="~/images/indianSNAP.jpg", NumberServings=4}, //
                new Recipe{Name="Quick bowl", Ingredients= snapBowlIngreds, ImageUrl="~/images/beansricegreens.jpg", NumberServings=1} //Ingredients= snapBowlIngreds,
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();

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
                new MealPlanRecipe{RecipeID=3,MealPlanID=2},
                new MealPlanRecipe{RecipeID=4,MealPlanID=1},
                new MealPlanRecipe{RecipeID=4,MealPlanID=2},
                new MealPlanRecipe{RecipeID=4,MealPlanID=3},
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
