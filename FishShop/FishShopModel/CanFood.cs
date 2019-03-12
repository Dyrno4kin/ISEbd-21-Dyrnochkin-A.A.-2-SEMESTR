using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("CanFoodId")]
        public virtual List<CanFoodIngredient> CanFoodIngredients { get; set; }
        [ForeignKey("CanFoodId")]
        public virtual List<CanFoodIngredient> CanFoodIngredients { get; set; }

    }
}
