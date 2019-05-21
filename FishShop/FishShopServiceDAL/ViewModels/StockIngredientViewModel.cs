using System.ComponentModel;
using System.Runtime.Serialization;

namespace FishShopServiceDAL.ViewModels
{
    [DataContract]
    public class StockIngredientViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StockId { get; set; }
        [DataMember]
        public int IngredientId { get; set; }
        [DisplayName("Название ингредиента")]
        [DataMember]
        public string IngredientName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
    }
}
