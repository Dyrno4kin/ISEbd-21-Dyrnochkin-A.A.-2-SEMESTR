using FishShopModel;
using System.Collections.Generic;

namespace FishShopServiceImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Customer> Customers { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Order> Orders { get; set; }
        public List<CanFood> CanFoods { get; set; }
        public List<CanFoodIngredient> CanFoodIngredients { get; set; }
        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Ingredients = new List<Ingredient>();
            Orders = new List<Order>();
            CanFoods = new List<CanFood>();
            CanFoodIngredients = new List<CanFoodIngredient>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
