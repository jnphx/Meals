using System.ComponentModel.DataAnnotations;

namespace WeeklyMeals.Models.WeeklyMealsViewModels
{
    public class FoodsGroup
    {
        public string AisleName;

        public string FoodName;

        public double TotalAmount;

        public string AmountType;

        public string PrepType;

        public int NumberBatches;
    }
}