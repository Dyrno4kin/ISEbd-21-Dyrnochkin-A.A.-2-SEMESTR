using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FishShopServiceDAL.ViewModels
{
    [DataContract]
    public class StocksLoadViewModel
    {
        [DataMember]
        public string StockName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public IEnumerable<Tuple<string, int>> Ingredients { get; set; }
    }
}