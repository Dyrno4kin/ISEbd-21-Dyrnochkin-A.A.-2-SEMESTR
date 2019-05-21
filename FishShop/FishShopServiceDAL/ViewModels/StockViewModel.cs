using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FishShopServiceDAL.ViewModels
{
    [DataContract]
    public class StockViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название склада")]
        [DataMember]
        public string StockName { get; set; }
        [DataMember]
        public List<StockIngredientViewModel> StockIngredients { get; set; }
    }
}
