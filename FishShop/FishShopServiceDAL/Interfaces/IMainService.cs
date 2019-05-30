using FishShopServiceDAL.Attributies;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с заказом")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<OrderViewModel> GetList();

        [CustomMethod("Метод получения списка свободных сотрудников")]
        List<OrderViewModel> GetFreeOrders();

        [CustomMethod("Метод создания заказа")]
        void CreateOrder(OrderBindingModel model);

        [CustomMethod("Метод передачи заказа в работу")]
        void TakeOrderInWork(OrderBindingModel model);

        [CustomMethod("Метод завершения заказа")]
        void FinishOrder(OrderBindingModel model);

        [CustomMethod("Метод оплаты заказа")]
        void PayOrder(OrderBindingModel model);

        [CustomMethod("Метод добавления ингредиентов на склад")]
        void PutIngredientOnStock(StockIngredientBindingModel model);
    }

}
