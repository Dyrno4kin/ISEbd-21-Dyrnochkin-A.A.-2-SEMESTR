using System.Collections.Generic;
using System.ComponentModel;

namespace FishShopServiceDAL.ViewModels
{
    public class StockViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string StockName { get; set; }
        public List<StockIngredientViewModel> StockIngredients { get; set; }
    }
}