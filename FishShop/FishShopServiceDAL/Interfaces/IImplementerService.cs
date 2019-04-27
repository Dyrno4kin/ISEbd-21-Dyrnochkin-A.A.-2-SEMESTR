using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace FishShopServiceDAL.Interfaces
{
    public interface IImplementerService
    {
        List<ImplementerViewModel> GetList();
        ImplementerViewModel GetElement(int id);
        void AddElement(ImplementerBindingModel model);
        void UpdElement(ImplementerBindingModel model);
        void DelElement(int id);
        ImplementerViewModel GetFreeWorker();
    }
}
