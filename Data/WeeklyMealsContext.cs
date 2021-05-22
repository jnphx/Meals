using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeeklyMeals.Models;

namespace WeeklyMeals.Data
{
    public class WeeklyMealsContext : DbContext
    {
        public WeeklyMealsContext(DbContextOptions<WeeklyMealsContext> options)
            : base(options)
        {
        }

        public DbSet<WeeklyMeals.Models.MealPlan> MealPlans { get; set; }
        public DbSet<WeeklyMeals.Models.Recipe> Recipes {get; set; }
        public DbSet<WeeklyMeals.Models.Step> Steps { get; set; }
        public DbSet<WeeklyMeals.Models.Ingredient> Ingredients { get; set; }
        public DbSet<WeeklyMeals.Models.SizeType> SizeTypes { get; set; }
        public DbSet<WeeklyMeals.Models.PrepType> PrepTypes { get; set; }
        public DbSet<WeeklyMeals.Models.GroceryAisle> GroceryAisles { get; set; }
        public DbSet<WeeklyMeals.Models.Food> Foods { get; set; }
        public DbSet<WeeklyMeals.Models.MealPlanRecipe> MealPlanRecipes { get; set; }
        public DbSet<WeeklyMeals.Models.UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealPlan>().ToTable("MealPlan");
            modelBuilder.Entity<MealPlanRecipe>().ToTable("MealPlanRecipe");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<Step>().ToTable("Step");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<PrepType>().ToTable("PrepType");
            modelBuilder.Entity<SizeType>().ToTable("SizeType");
            modelBuilder.Entity<GroceryAisle>().ToTable("GroceryAisle");
            modelBuilder.Entity<UserSettings>().ToTable("UserSettings");
        } 
    }
}
