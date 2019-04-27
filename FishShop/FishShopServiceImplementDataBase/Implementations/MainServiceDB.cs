using FishShopModel;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;

namespace FishShopServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private FishDbContext context;
        public MainServiceDB(FishDbContext context)
        {
            this.context = context;
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = context.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                CanFoodId = rec.CanFoodId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
           rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = rec.Customer.CustomerFIO,
                CanFoodName = rec.CanFood.CanFoodName,
                ImplementerId = rec.Implementer.Id,
                ImplementerName = rec.Implementer.ImplementerFIO
            })
            .ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            context.Orders.Add(new Order
            {
                CustomerId = model.CustomerId,
                CanFoodId = model.CanFoodId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
        using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != OrderStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var CanFoodIngredients = context.CanFoodIngredients.Include(rec => rec.Ingredient).Where(rec => rec.CanFoodId == element.CanFoodId);
                    // списываем
                    foreach (var CanFoodIngredient in CanFoodIngredients)
                    {
                        int countOnStocks = CanFoodIngredient.Count * element.Count;
                        var stockIngredients = context.StockIngredients.Where(rec =>
                        rec.IngredientId == CanFoodIngredient.IngredientId);
                        foreach (var stockIngredient in stockIngredients)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (stockIngredient.Count >= countOnStocks)
                            {
                                stockIngredient.Count -= countOnStocks;
                                countOnStocks = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStocks -= stockIngredient.Count;
                                stockIngredient.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStocks > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                           CanFoodIngredient.Ingredient.IngredientName + " требуется " + CanFoodIngredient.Count + ", нехватает " + countOnStocks);
                         }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Выполняется;
                    element.ImplementerId = model.ImplementerId;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
        {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
            context.SaveChanges();
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
            context.SaveChanges();
        }

        public List<OrderViewModel> GetFreeOrders()
        {
            List<OrderViewModel> result = context.Orders
            .Where(x => x.Status == OrderStatus.Принят || x.Status ==
           OrderStatus.НедостаточноРесурсов)
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id
            })
            .ToList();
            return result;
        }

        public void PutIngredientOnStock(StockIngredientBindingModel model)
        {
            StockIngredient element = context.StockIngredients.FirstOrDefault(rec =>
           rec.StockId == model.StockId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StockIngredients.Add(new StockIngredient
                {
                    StockId = model.StockId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
