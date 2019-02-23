using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopModel
{
    public class CanFoodIngredient
    {
        public int Id { get; set; }
        public int CanFoodId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
