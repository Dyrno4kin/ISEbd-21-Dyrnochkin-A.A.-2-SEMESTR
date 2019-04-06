using System.Runtime.Serialization;

namespace FishShopServiceDAL.BindingModels
{
    [DataContract]
    public class StockIngredientBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StockId { get; set; }
        [DataMember]
        public int IngredientId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
