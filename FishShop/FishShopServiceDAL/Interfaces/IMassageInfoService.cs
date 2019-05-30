using FishShopServiceDAL.Attributies;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с сообщениями")]
    public interface IMessageInfoService
    {
        [CustomMethod("Метод получения списка сообщений")]
        List<MessageInfoViewModel> GetList();

        [CustomMethod("Метод получения сообщения по id")]
        MessageInfoViewModel GetElement(int id);

        [CustomMethod("Метод добавления сообщения")]
        void AddElement(MessageInfoBindingModel model);
    }
}
