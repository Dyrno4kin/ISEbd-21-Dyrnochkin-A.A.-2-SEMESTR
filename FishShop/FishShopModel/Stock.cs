using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishShopModel
{
    /// <summary>
    /// Хранилиище ингдериентов в магазине
    /// </summary>
    public class Stock
    {
        public int Id { get; set; }

        [Required]
        public string StockName { get; set; }

        [ForeignKey("StockId")]
        public virtual List<StockIngredient> StockIngredients { get; set; }

    }
}
