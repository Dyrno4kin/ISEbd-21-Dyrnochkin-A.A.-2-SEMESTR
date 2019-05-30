using System.Collections.Generic;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;

namespace FishShopServiceDAL.Interfaces
{
    public interface IStockService
    {
        List<StockViewModel> GetList();
        StockViewModel GetElement(int id);
        void AddElement(StockBindingModel model);
        void UpdElement(StockBindingModel model);
        void DelElement(int id);
    }
}