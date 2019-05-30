using FishShopServiceDAL.Attributies;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с консервой")]
    public interface ICanFoodService
    {
        [CustomMethod("Метод получения списка консерв")]
        List<CanFoodViewModel> GetList();

        [CustomMethod("Метод получения консерв по id")]
        CanFoodViewModel GetElement(int id);

        [CustomMethod("Метод добавления консерв")]
        void AddElement(CanFoodBindingModel model);

        [CustomMethod("Метод изменения данных по консервам")]
        void UpdElement(CanFoodBindingModel model);

        [CustomMethod("Метод удаления консерв")]
        void DelElement(int id);
    }
}
