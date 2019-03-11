using System;
using System.Collections.Generic;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
