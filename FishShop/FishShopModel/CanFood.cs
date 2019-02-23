using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopModel
{
    /// <summary>
    /// Консерва, изготавливаемая на заводе
    /// </summary>
    public class CanFood
    {
        public int Id { get; set; }
        public string CanFoodName { get; set; }
        public decimal Price { get; set; }
    }
}
