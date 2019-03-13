using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopModel
{
    /// <summary>
    /// Ингридиент, требуемый для изготовления консерв
    /// </summary>
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<CanFoodIngredient> CanFoodIngredients { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<StockIngredient> StockIngredients { get; set; }
    }
}
