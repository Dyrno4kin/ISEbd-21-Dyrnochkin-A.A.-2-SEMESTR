using FishShopServiceDAL.Attributies;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с заказчиками")]
    public interface ICustomerService
    {
        [CustomMethod("Метод получения списка заказчиков")]
        List<CustomerViewModel> GetList();

        [CustomMethod("Метод получения заказчика по id")]
        CustomerViewModel GetElement(int id);

        [CustomMethod("Метод добавления заказчика")]
        void AddElement(CustomerBindingModel model);

        [CustomMethod("Метод изменения данных по заказчику")]
        void UpdElement(CustomerBindingModel model);

        [CustomMethod("Метод удаления заказчика")]
        void DelElement(int id);
    }
}