﻿using System.Runtime.Serialization;

namespace FishShopServiceDAL.BindingModels
{
    [DataContract]
    public class IngredientBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string IngredientName { get; set; }
    }
}
