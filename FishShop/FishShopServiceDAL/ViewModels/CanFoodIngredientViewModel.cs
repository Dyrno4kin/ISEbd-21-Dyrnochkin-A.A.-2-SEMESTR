using System.Runtime.Serialization;

namespace FishShopServiceDAL.ViewModels
{
    [DataContract]
    public class CanFoodIngredientViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CanFoodId { get; set; }
        [DataMember]
        public int IngredientId { get; set; }
        [DataMember]
        public string IngredientName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
