﻿using System.Runtime.Serialization;

namespace FishShopServiceDAL.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public int CanFoodId { get; set; }
        [DataMember]
        public string CanFoodName { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public string ImplementerName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
    }
}
