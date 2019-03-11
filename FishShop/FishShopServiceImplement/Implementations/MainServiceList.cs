using FishShopModel;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<OrderViewModel> result = source.Orders
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    CanFoodId = rec.CanFoodId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    CustomerFIO = source.Customers.FirstOrDefault(recI => recI.Id ==
     rec.CustomerId)?.CustomerFIO,
                    CanFoodName = source.CanFoods.FirstOrDefault(recC => recC.Id ==
    rec.CanFoodId)?.CanFoodName,
                })                .ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
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
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var canFoodIngredients = source.CanFoodIngredients.Where(rec => rec.CanFoodId
           == element.CanFoodId);
            foreach (var canFoodIngredient in canFoodIngredients)
            {
                int countOnStocks = source.StockIngredients
                .Where(rec => rec.IngredientId ==
               canFoodIngredient.IngredientId)
               .Sum(rec => rec.Count);
                if (countOnStocks < canFoodIngredient.Count * element.Count)
                {
                    var ingredientName = source.Ingredients.FirstOrDefault(rec => rec.Id ==
                   canFoodIngredient.IngredientId);
                    throw new Exception("Не достаточно ингредиента " +
                   ingredientName?.IngredientName + " требуется " + (canFoodIngredient.Count * element.Count) +
                   ", в наличии " + countOnStocks);
                }
            }
            // списываем
            foreach (var canFoodIngredient in canFoodIngredients)
            {
                int countOnStocks = canFoodIngredient.Count * element.Count;
                var stockIngredients = source.StockIngredients.Where(rec => rec.IngredientId
               == canFoodIngredient.IngredientId);
                foreach (var stockIngredient in stockIngredients)
                {
                    // ингредиентов на одном слкаде может не хватать
                    if (stockIngredient.Count >= countOnStocks)
                    {
                        stockIngredient.Count -= countOnStocks;
                        break;
                    }
                    else
                    {
                        countOnStocks -= stockIngredient.Count;
                        stockIngredient.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }

        public void FinishOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
        }

        public void PayOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
        }

        public void PutIngredientOnStock(StockIngredientBindingModel model)
        {
            StockIngredient element = source.StockIngredients.FirstOrDefault(rec =>
           rec.StockId == model.StockId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StockIngredients.Count > 0 ?
               source.StockIngredients.Max(rec => rec.Id) : 0;
                source.StockIngredients.Add(new StockIngredient
                {
                    Id = ++maxId,
                    StockId = model.StockId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
        }
    }
}
