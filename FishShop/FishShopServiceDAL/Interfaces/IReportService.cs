using FishShopServiceDAL.Attributies;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;
namespace FishShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReportService
    {
        [CustomMethod("Метод для сохранения прайс-листа")]
        void SaveCanFoodPrice(ReportBindingModel model);

        [CustomMethod("Метод для получения загрузки склада")]
        List<StocksLoadViewModel> GetStocksLoad();

        [CustomMethod("Метод для сохранения загрузки складов")]
        void SaveStocksLoad(ReportBindingModel model);

        [CustomMethod("Метод для получения заказов")]
        List<CustomerOrdersViewModel> GetCustomerOrders(ReportBindingModel model);

        [CustomMethod("Метод для сохранения заказов")]
        void SaveCustomerOrders(ReportBindingModel model);
    }
}