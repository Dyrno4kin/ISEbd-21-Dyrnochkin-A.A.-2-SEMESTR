using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    public interface ICanFoodService
    {
        List<CanFoodViewModel> GetList();
        CanFoodViewModel GetElement(int id);
        void AddElement(CanFoodBindingModel model);
        void UpdElement(CanFoodBindingModel model);
        void DelElement(int id);
    }
}
