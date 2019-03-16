using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<OrderViewModel> GetList();
        void CreateOrder(OrderBindingModel model);
        void TakeOrderInWork(OrderBindingModel model);
        void FinishOrder(OrderBindingModel model);
        void PayOrder(OrderBindingModel model);
    }
}
