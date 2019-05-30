using System.Collections.Generic;
using FishShopServiceDAL.Attributies;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;

namespace FishShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы со складами")]
    public interface IStockService
    {
        [CustomMethod("Метод для получения списка складов")]
        List<StockViewModel> GetList();

        [CustomMethod("Метод для получения склада по id")]
        StockViewModel GetElement(int id);

        [CustomMethod("Метод для добавления склада")]
        void AddElement(StockBindingModel model);

        [CustomMethod("Метод для изменения склада")]
        void UpdElement(StockBindingModel model);

        [CustomMethod("Метод для удаления склада")]
        void DelElement(int id);
    }
}
