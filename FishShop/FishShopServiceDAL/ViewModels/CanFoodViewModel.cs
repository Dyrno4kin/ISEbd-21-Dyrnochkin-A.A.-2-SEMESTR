using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopServiceDAL.ViewModels
{
    public class CanFoodViewModel
    {
        public int Id { get; set; }
        public string CanFoodName { get; set; }
        public decimal Price { get; set; }
        public List<CanFoodIngredientViewModel> CanFoodIngredients { get; set; }
    }
}
