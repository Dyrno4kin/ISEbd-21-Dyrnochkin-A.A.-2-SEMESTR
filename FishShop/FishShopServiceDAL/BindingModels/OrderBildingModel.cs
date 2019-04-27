using System.Runtime.Serialization;

namespace FishShopServiceDAL.BindingModels
{
    [DataContract]
    public class OrderBindingModel
  {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int CanFoodId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
  }

}
