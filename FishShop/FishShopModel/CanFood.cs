using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishShopModel
{
    /// <summary>
    /// Консерва, изготавливаемая на заводе
    /// </summary>
    public class CanFood
    {
        public int Id { get; set; }
        [Required]
        public string CanFoodName { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CanFoodId")]
        public virtual List<CanFoodIngredient> CanFoodIngredients { get; set; }
        [ForeignKey("CanFoodId")]
        public virtual List<Order> Orders { get; set; }

    }
}
