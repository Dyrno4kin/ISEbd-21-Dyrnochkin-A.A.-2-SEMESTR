using System;
using System.Collections.Generic;
namespace FishShopServiceDAL.ViewModels
{
    public class StocksLoadViewModel
    {
        public string StockName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Ingredients { get; set; }
    }
}