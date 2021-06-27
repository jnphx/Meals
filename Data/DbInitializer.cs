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
            var ounce = new SizeType { Name = "ounce" };
            var TB = new SizeType { Name = "TB" };
            var lb = new SizeType { Name = "lb" };

            var sizeTypes = new SizeType[]
            {
                cup,
                new SizeType { Name = "TB" },
                tsp,
                new SizeType { Name = "ou" },
                lb,
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
            var thaw = new PrepType { Name = "thaw" };
            var grated = new PrepType { Name = "grated" };

            var prepTypes = new PrepType[]
            {
                noprep,
                chop,
                steam,
                precook,
                thaw,
                new PrepType { Name = "cook beans" },
                new PrepType { Name = "make sauce" },
                grated
            };
            context.PrepTypes.AddRange(prepTypes);
            context.SaveChanges();

            var grainsBeans = new GroceryAisle { Name = "Grains/Beans" };
            var produce = new GroceryAisle { Name = "Produce" };
            var spices = new GroceryAisle { Name = "Spices" };
            var canned = new GroceryAisle { Name = "Canned goods" };
            var frozen = new GroceryAisle { Name = "Frozen" };
            var condiments = new GroceryAisle { Name = "Condiments" };

            var groceryAisles = new GroceryAisle[]
            {
                produce,
                grainsBeans,
                condiments,
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
            var frozenVeg = new Food { Name = "veg (any)", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var anyCookedGrain = new Food { Name = "cooked grains (any)", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var anyCannedBeans = new Food { Name = "canned beans (any)", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var frozenPeas = new Food { Name = "12 oz frozen peas", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var canTomatoes = new Food { Name = "16 ou tomatoes", GroceryAisle = canned, CookedCupsConversion = 2 };
            var canBlackBeans = new Food { Name = "black beans", GroceryAisle = canned, CookedCupsConversion = 2 };
            var greenPeppers = new Food { Name = "green pepper", GroceryAisle = produce };
            var chiliPowder = new Food { Name = "chili powder", GroceryAisle = spices };
            var curry = new Food { Name = "curry powder", GroceryAisle = spices };
            var coriander = new Food { Name = "coriander", GroceryAisle = spices };
            var appleCiderVinegar = new Food { Name = "apple cider vinegar", GroceryAisle = condiments };
            var carrot = new Food { Name = "carrot", GroceryAisle = produce };
            var collardGreens = new Food { Name = "collard greens", GroceryAisle = produce };
            var cookedQuinoa = new Food { Name = "cooked quinoa", GroceryAisle = grainsBeans };
            var corn = new Food { Name = "corn", GroceryAisle = frozen };
            var freshGinger = new Food { Name = "fresh ginger", GroceryAisle = produce };
            var garlicPowder = new Food { Name = "garlic powder", GroceryAisle = spices };
            var greenOnions = new Food { Name = "green onions", GroceryAisle = produce };
            var kale = new Food { Name = "kale", GroceryAisle = produce };
            var kidneyBeans = new Food { Name = "kidney beans", GroceryAisle = grainsBeans };
            var mapleSyrup = new Food { Name = "maple syrup", GroceryAisle = condiments };
            var redPepper = new Food { Name = "red pepper", GroceryAisle = produce };
            var bellPepper = new Food { Name = "bell pepper", GroceryAisle = produce };
            var napaCabbage = new Food { Name = "napa cabbage", GroceryAisle = produce };
            var riceVinegar = new Food { Name = "rice vinegar", GroceryAisle = condiments };
            var salsaVerde = new Food { Name = "salsa verde", GroceryAisle = condiments };
            var smallTomato = new Food { Name = "small tomato", GroceryAisle = produce };
            var sweetPotato = new Food { Name = "sweet potato", GroceryAisle = produce };
            var tahini = new Food { Name = "tahini", GroceryAisle = condiments };
            var toastedSesameSeeds = new Food { Name = "toasted sesame seeds", GroceryAisle = condiments };
            var tamari = new Food { Name = "tamari", GroceryAisle = condiments };
            var yellowSquash = new Food { Name = "yellow squash", GroceryAisle = produce };
            var celery = new Food { Name = "celery", GroceryAisle = produce };
            var thyme = new Food { Name = "thyme", GroceryAisle = spices };

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
                coriander,
                salsaVerde,
                appleCiderVinegar,
                smallTomato,
                yellowSquash,
                greenOnions,
                napaCabbage,
                corn,
                cookedQuinoa,
                kidneyBeans,
                carrot,
                redPepper,
                riceVinegar,
                tahini,
                tamari,
                mapleSyrup,
                freshGinger,
                garlicPowder,
                toastedSesameSeeds,
                kale,
                sweetPotato,
                collardGreens,
                celery,
                thyme
            };
            context.Foods.AddRange(foods);
            context.SaveChanges();

            var ingredLentils = new Ingredient { Food = lentils, PrepType = noprep, Size = 0.5, SizeType = cup };
            var ingredOnions = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeType = cup };
            var ingredOnions1 = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeType = cup };
            var ingredMushrooms = new Ingredient { Food = mushrooms, PrepType = chop, Size = .5, MaxSize=1, SizeType = lb, Optional=true };
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
            var ingredAnyFrozenVeg = new Ingredient { Food = frozenVeg, PrepType = noprep, Size = 6, SizeType = ounce };
            //veg, grain - on recipe, show as cup, in grocery list show as ounces. beans - recipe: cup, grocery: can
            var ingredAnyGrain = new Ingredient { Food = anyCookedGrain, PrepType = precook, Size = 1, SizeType = cup };
            var ingredAnyBeans = new Ingredient { Food = anyCannedBeans, PrepType = drain, Size = .25, SizeType = can };
            var ingredFrozenPeas = new Ingredient { Food = frozenPeas, PrepType = noprep, Size = .25, SizeType = cup };
            var ingredChiliCumin = new Ingredient { Food = cumin, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredChilipowder = new Ingredient { Food = chiliPowder, PrepType = noprep, Size = 4, SizeType = tsp };
            var ingredChilipowder1 = new Ingredient { Food = chiliPowder, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredCurry = new Ingredient { Food = curry, PrepType = noprep, Size = 1, SizeType = tsp };
            var ingredCoriander = new Ingredient { Food = coriander, PrepType = noprep, Size = .5, SizeType = tsp };
            var ingredSalsaVerde = new Ingredient { Food = salsaVerde, PrepType = noprep, Size = .75, SizeType = cup };
            var ingredapplecidervinegar = new Ingredient { Food = appleCiderVinegar, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredsmallTomato = new Ingredient { Food = smallTomato, PrepType = chop, Size = 1, SizeType = each };
            var ingredyellowSquash = new Ingredient { Food = yellowSquash, PrepType = chop, Size = 1, SizeType = each };
            var ingredgreenOnions = new Ingredient { Food = greenOnions, PrepType = chop, Size = 4, SizeType = each };
            var ingrednapaCabbage = new Ingredient { Food = napaCabbage, PrepType = chop, Size = 2, SizeType = cup };
            var ingredcorn = new Ingredient { Food = corn, PrepType = noprep, Size = .5, SizeType = cup };
            var ingredcookedQuinoa = new Ingredient { Food = cookedQuinoa, PrepType = noprep, Size = .5, SizeType = cup };
            var ingredkidneyBeans = new Ingredient { Food = kidneyBeans, PrepType = noprep, Size = .5, SizeType = cup };
            var ingredcookedQuinoa2 = new Ingredient { Food = cookedQuinoa, PrepType = noprep, Size = 2, SizeType = cup };
            var ingredPeas2 = new Ingredient { Food = frozenPeas, PrepType = thaw, Size = .5, SizeType = cup };
            var ingredCarrot = new Ingredient { Food = carrot, PrepType = grated, Size = .5, SizeType = cup };
            var ingredredPepper = new Ingredient { Food = redPepper, PrepType = chop, Size = .25, SizeType = cup };
            var ingredgreenOnions2 = new Ingredient { Food = greenOnions, PrepType = chop, Size = 1, SizeType = TB };
            var ingredriceVinegar = new Ingredient { Food = riceVinegar, PrepType = noprep, Size = 3, SizeType = TB };
            var ingredTahini = new Ingredient { Food = tahini, PrepType = noprep, Size = 1.5, SizeType = TB };
            var ingredTamari = new Ingredient { Food = tamari, PrepType = noprep, Size = 2, SizeType = TB };
            var ingredMapleSyrup = new Ingredient { Food = mapleSyrup, PrepType = noprep, Size = 1.5, SizeType = TB };
            var ingredginger = new Ingredient { Food = freshGinger, PrepType = grated, Size = 1, SizeType = tsp };
            var ingredgarlicpowder = new Ingredient { Food = garlicPowder, PrepType = grated, Size = .25, SizeType = tsp };
            var ingredtoastedSesameseeds = new Ingredient { Food = toastedSesameSeeds, PrepType = grated, Size = 1, SizeType = TB };
            var ingredMushrooms1 = new Ingredient { Food = mushrooms, PrepType = chop, Size = .5, MaxSize=1, SizeType = lb, Optional = true };
            var ingredCarrots1   = new Ingredient { Food = carrot, PrepType = chop, Size = 2, SizeType = each };
            var ingredCelery = new Ingredient { Food = celery, PrepType = chop, Size = 1, SizeType = each };
            var ingredLentils1 = new Ingredient { Food = lentils, PrepType = noprep, Size = 1, SizeType = cup };
            var ingredOnions2 = new Ingredient { Food = onions, PrepType = chop, Size = 1, SizeType = cup };
            var ingredGarlic2 = new Ingredient { Food = garlic, PrepType = chop, Size = 2, SizeType = clove };
            var ingredThyme = new Ingredient { Food = thyme, PrepType = noprep, Size = 1, SizeType = tsp };

            var frenchLentils = new Ingredient[]
            {
                ingredMushrooms1,
                ingredCarrots1,
                ingredCelery,
                ingredLentils1,
                ingredOnions2,
                ingredGarlic2,
                ingredThyme
            };

            var sesamequinoaSalad = new Ingredient[]
           {
                ingredcookedQuinoa2,
                ingredPeas2,
                ingredCarrot,
                ingredredPepper,
                ingredgreenOnions2,
                ingredriceVinegar,
                ingredTahini,
                ingredTamari,
                ingredMapleSyrup,
                ingredginger,
                ingredgarlicpowder,
                ingredtoastedSesameseeds
           };

            var redbeanSalad = new Ingredient[]
            {
                ingredSalsaVerde,
                ingredapplecidervinegar,
                ingredsmallTomato,
                ingredyellowSquash,
                ingredgreenOnions,
                ingrednapaCabbage,
                ingredcorn,
                ingredcookedQuinoa,
                ingredkidneyBeans
            };

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
                new Recipe{Name="Lentils & Rice", Steps = steps, Ingredients = lentilRiceIngreds, ImageUrl = "~/images/lentilsandrice.jpg", NumberServings = 6, VegServingsMissing=1, PercentForYou=.5},
                new Recipe{Name="Black bean chili", Ingredients = chiliIngreds, ImageUrl = "~/images/chili.jpg", NumberServings = 8, GrainServingsMissing=1, VegServingsMissing=1, PercentForYou=.75},
                //new Recipe{Name="Pinto bean chili"},
                //new Recipe{Name="Peanut stir-fry"},
                new Recipe{Name="French lentils", Ingredients = frenchLentils, ImageUrl = "~/images/frenchlentils.jpg", NumberServings = 8, VegServingsMissing=1},
                new Recipe{Name="Quick Mexican", Ingredients= snapIngreds, ImageUrl="~/images/beansrice.jpg", NumberServings=4},
                new Recipe{Name="Quick Indian", Ingredients= snapIndianIngreds, ImageUrl="~/images/indianSNAP.jpg", NumberServings=4},
                new Recipe{Name="Quick bowl", Ingredients= snapBowlIngreds, ImageUrl="~/images/beansricegreens.jpg", NumberServings=1},
                new Recipe{Name="Quinoa and Red Bean Salad", Ingredients=redbeanSalad, ImageUrl="~/images/quinoaredbean.jpg", NumberServings=2 },
                new Recipe{Name="Sesame Quinoa Salad", Ingredients=sesamequinoaSalad, ImageUrl="~/images/sesamequinoasalad.jpg", NumberServings=2 }
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
