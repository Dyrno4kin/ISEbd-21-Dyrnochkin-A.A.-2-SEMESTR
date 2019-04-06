using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FishShopServiceDAL.BindingModels
{
    /// <summary>
    /// Консерва, изготавливаемая на заводе
    /// </summary>
    [DataContract]
    public class CanFoodBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CanFoodName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<CanFoodIngredientBindingModel> CanFoodIngredients { get; set; }
    }
}
