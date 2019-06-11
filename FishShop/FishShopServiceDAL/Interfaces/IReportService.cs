using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;
namespace FishShopServiceDAL.Interfaces
{
    public interface IReportService
    {
        void SaveCanFoodPrice(ReportBindingModel model);
        List<StocksLoadViewModel> GetStocksLoad();
        void SaveStocksLoad(ReportBindingModel model);
        List<CustomerOrdersViewModel> GetCustomerOrders(ReportBindingModel model);
        void SaveCustomerOrders(ReportBindingModel model);
    }
}