using FishShopModel;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
namespace FishShopServiceImplement.Implementations
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                string customerFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].Id == source.Orders[i].CustomerId)
                    {
                        customerFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string canFoodName = string.Empty;
                for (int j = 0; j < source.CanFoods.Count; ++j)
                {
                    if (source.CanFoods[j].Id == source.Orders[i].CanFoodId)
                    {
                        canFoodName = source.CanFoods[j].CanFoodName;
                        break;
                    }
                }
                result.Add(new OrderViewModel
                {
                    Id = source.Orders[i].Id,
                    CustomerId = source.Orders[i].CustomerId,
                    CustomerFIO = customerFIO,
                    CanFoodId = source.Orders[i].CanFoodId,
                    CanFoodName = canFoodName,
                    Count = source.Orders[i].Count,
                    Sum = source.Orders[i].Sum,
                    DateCreate = source.Orders[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Orders[i].DateImplement?.ToLongDateString(),
                    Status = source.Orders[i].Status.ToString()
                });
            }
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId =0;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
            }
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                CanFoodId = model.CanFoodId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Orders[index].DateImplement = DateTime.Now;
            source.Orders[index].Status = OrderStatus.Выполняется;
        }
        public void FinishOrder(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Orders[index].Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Orders[index].Status = OrderStatus.Оплачен;
        }
    }
}
