using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FishShopServiceDAL.ViewModels
{
    [DataContract]
    public class CanFoodViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CanFoodName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<CanFoodIngredientViewModel> CanFoodIngredients { get; set; }
    }
}
