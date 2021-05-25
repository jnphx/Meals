using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var sizeTypes = new SizeType[]
            {
                new SizeType { Name = "cup" },
                new SizeType { Name = "TB" },
                new SizeType { Name = "tsp" },
                new SizeType { Name = "ou" },
                new SizeType { Name = "lb" },
                new SizeType { Name = "can" },
                new SizeType { Name = "each" },
                new SizeType { Name = "clove" }
            };
            context.SizeTypes.AddRange(sizeTypes);
            context.SaveChanges();

            var chop = new PrepType { Name = "Chop" };
            var noprep = new PrepType { Name = "No prep" };

            var prepTypes = new PrepType[]
            {
                new PrepType {Name = "No prep"},
                chop,
                new PrepType { Name = "Cook grains" },
                new PrepType { Name = "Cook beans" },
                new PrepType { Name = "Make sauce" }
            };
            context.PrepTypes.AddRange(prepTypes);
            context.SaveChanges();

            var grainsBeans = new GroceryAisle { Name = "Grains/Beans" };
            var produce = new GroceryAisle { Name = "Produce" };

            var groceryAisles = new GroceryAisle[]
            {
                produce,
                grainsBeans,
                new GroceryAisle { Name = "Condiments" },
                new GroceryAisle { Name = "Plant milk" },
                new GroceryAisle { Name = "Frozen" },
                new GroceryAisle { Name = "Canned goods" },
                new GroceryAisle { Name = "Spices" }
            };
            context.GroceryAisles.AddRange(groceryAisles);
            context.SaveChanges();

            var lentils = new Food { Name = "Lentils", GroceryAisle = grainsBeans };
            var basmati = new Food { Name = "Basmati rice", GroceryAisle = grainsBeans };
            var garlic = new Food { Name = "Garlic", GroceryAisle = produce };
            var onions = new Food { Name = "Onion", GroceryAisle = produce };

            var foods = new Food[]
            {
                lentils,
                basmati,
                garlic,
                onions,
                new Food { Name = "Mushrooms", GroceryAisleID=1 },
                onions,
                new Food { Name = "Vegetable stock", GroceryAisleID=6 },
                new Food { Name = "Cumin seeds", GroceryAisleID=7 }
            };
            context.Foods.AddRange(foods);
            context.SaveChanges();

            var ingredLentils = new Ingredient { Food = lentils, PrepType = noprep, Size = 0.5, SizeTypeID = 1 };
            var ingredOnions = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeTypeID = 1 };
            var ingredGarlic = new Ingredient { Food = garlic, PrepType = chop, Size = 0.5, SizeTypeID = 1 };

            var ingreds = new Ingredient[] {
                ingredLentils,
                ingredOnions,
                ingredGarlic,
            new Ingredient { FoodID = 5, PrepTypeID = 2, Size = 0.6, SizeTypeID = 1},
            new Ingredient { FoodID = 6, PrepTypeID = 2, Size = 0.7, SizeTypeID = 1},
            new Ingredient { FoodID = 7, PrepTypeID = 2, Size = 0.8, SizeTypeID = 1},
            new Ingredient { FoodID = 7, PrepTypeID = 2, Size = 0.9, SizeTypeID = 1},
            new Ingredient { FoodID = 6, PrepTypeID = 2, Size = 2.2, SizeTypeID = 1},
            new Ingredient { FoodID = 2, PrepTypeID = 2, Size = 1.1, SizeTypeID = 1},
            new Ingredient { FoodID = 1, PrepTypeID = 2, Size = 1.2, SizeTypeID = 1},
            new Ingredient { FoodID = 4, PrepTypeID = 2, Size = 0.3, SizeTypeID = 1}

        };

            var ingredients = new Ingredient[]
            {
                new Ingredient { FoodID = 2, PrepTypeID = 2, Size = 0.23, SizeTypeID = 1},
                new Ingredient { FoodID = 1, PrepTypeID = 2, Size = 0.4, SizeTypeID = 2},
                ingredLentils,
                ingredOnions,
                ingredGarlic,
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
                new Recipe{Name="Lentils & Rice", Steps = steps, Ingredients = ingredients},
                new Recipe{Name="Black bean chili"},
                //new Recipe{Name="Pinto bean chili"},
                //new Recipe{Name="Peanut stir-fry"},
                new Recipe{Name="French lentils"}
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
                new MealPlanRecipe{RecipeID=1,MealPlanID=1},
                new MealPlanRecipe{RecipeID=1,MealPlanID=2},
                new MealPlanRecipe{RecipeID=1,MealPlanID=3},
                new MealPlanRecipe{RecipeID=2,MealPlanID=2},
                new MealPlanRecipe{RecipeID=2,MealPlanID=3},
                new MealPlanRecipe{RecipeID=3,MealPlanID=3},
                new MealPlanRecipe{RecipeID=3,MealPlanID=1},
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
