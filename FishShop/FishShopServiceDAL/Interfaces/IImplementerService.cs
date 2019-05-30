using FishShopServiceDAL.Attributies;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с сотрудниками")]
    public interface IImplementerService
    {
        [CustomMethod("Метод получения списка сотрудников")]
        List<ImplementerViewModel> GetList();

        [CustomMethod("Метод получения сотрудника по id")]
        ImplementerViewModel GetElement(int id);

        [CustomMethod("Метод добавления сотрудника")]
        void AddElement(ImplementerBindingModel model);

        [CustomMethod("Метод изменения данных по сотруднику")]
        void UpdElement(ImplementerBindingModel model);

        [CustomMethod("Метод удаления сотрудника")]
        void DelElement(int id);

        [CustomMethod("Метод для получения свободного сотрудника")]
        ImplementerViewModel GetFreeWorker();
    }
}
