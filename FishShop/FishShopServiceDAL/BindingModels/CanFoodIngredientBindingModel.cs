using System.Runtime.Serialization;

namespace FishShopServiceDAL.BindingModels
{
    [DataContract]
    public class CanFoodIngredientBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CanFoodId { get; set; }
        [DataMember]
        public int IngredientId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
