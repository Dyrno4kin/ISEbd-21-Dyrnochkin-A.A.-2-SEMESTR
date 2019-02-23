using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopServiceDAL.ViewModels
{
    public class CanFoodIngredientViewModel
    {
        public int Id { get; set; }
        public int CanFoodId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int Count { get; set; }
    }
}
