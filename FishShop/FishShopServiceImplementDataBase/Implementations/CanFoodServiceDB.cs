using FishShopModel;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishShopServiceImplementDataBase.Implementations
{
    public class CanFoodServiceDB : ICanFoodService
    {
        private FishDbContext context;
        public CanFoodServiceDB(FishDbContext context)
        {
            this.context = context;
        }
        public List<CanFoodViewModel> GetList()
        {
            List<CanFoodViewModel> result = context.CanFoods.Select(rec => new
           CanFoodViewModel
            {
                Id = rec.Id,
                CanFoodName = rec.CanFoodName,
                Price = rec.Price,
                CanFoodIngredients = context.CanFoodIngredients
            .Where(recCI => recCI.CanFoodId == rec.Id)
           .Select(recCI => new CanFoodIngredientViewModel
           {
               Id = recCI.Id,
               CanFoodId = recCI.CanFoodId,
               IngredientId = recCI.IngredientId,
               IngredientName = recCI.Ingredient.IngredientName,
               Count = recCI.Count
           })
           .ToList()
            })
            .ToList();
            return result;
        }
        public CanFoodViewModel GetElement(int id)
        {
            CanFood element = context.CanFoods.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CanFoodViewModel
                {
                    Id = element.Id,
                    CanFoodName = element.CanFoodName,
                    Price = element.Price,
                    CanFoodIngredients = context.CanFoodIngredients
                    .Where(recCI => recCI.CanFoodId == element.Id)
                    .Select(recCI => new CanFoodIngredientViewModel
                    {
                        Id = recCI.Id,
                        CanFoodId = recCI.CanFoodId,
                        IngredientId = recCI.IngredientId,
                        IngredientName = recCI.Ingredient.IngredientName,
                        Count = recCI.Count
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CanFoodBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    CanFood element = context.CanFoods.FirstOrDefault(rec =>
                   rec.CanFoodName == model.CanFoodName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть консерва с таким названием");
                    }
                    element = new CanFood
                    {
                        CanFoodName = model.CanFoodName,
                        Price = model.Price
                    };
                    context.CanFoods.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupIngredients = model.CanFoodIngredients
                     .GroupBy(rec => rec.IngredientId)
                    .Select(rec => new
                    {
                        IngredientId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    // добавляем компоненты
                    foreach (var groupIngredient in groupIngredients)
                    {
                        context.CanFoodIngredients.Add(new CanFoodIngredient
                        {
                            CanFoodId = element.Id,
                            IngredientId = groupIngredient.IngredientId,
                            Count = groupIngredient.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(CanFoodBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    CanFood element = context.CanFoods.FirstOrDefault(rec =>
                   rec.CanFoodName == model.CanFoodName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.CanFoods.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.CanFoodName = model.CanFoodName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.CanFoodIngredients.Select(rec =>
                   rec.IngredientId).Distinct();
                    var updateIngredients = context.CanFoodIngredients.Where(rec =>
                   rec.CanFoodId == model.Id && compIds.Contains(rec.IngredientId));
                    foreach (var updateIngredient in updateIngredients)
                    {
                        updateIngredient.Count =
                       model.CanFoodIngredients.FirstOrDefault(rec => rec.Id == updateIngredient.Id).Count;
                    }
                    context.SaveChanges();
                    context.CanFoodIngredients.RemoveRange(context.CanFoodIngredients.Where(rec =>
                    rec.CanFoodId == model.Id && !compIds.Contains(rec.IngredientId)));
                    context.SaveChanges();
                    // новые записи
                    var groupIngredients = model.CanFoodIngredients
                    .Where(rec => rec.Id == 0)
                   .GroupBy(rec => rec.IngredientId)
                   .Select(rec => new
                   {
                       IngredientId = rec.Key,
                       Count = rec.Sum(r => r.Count)
                   });
                    foreach (var groupIngredient in groupIngredients)
                    {
                        CanFoodIngredient elementCI =
                       context.CanFoodIngredients.FirstOrDefault(rec => rec.CanFoodId == model.Id &&
                       rec.IngredientId == groupIngredient.IngredientId);
                        if (elementCI != null)
                        {
                            elementCI.Count += groupIngredient.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.CanFoodIngredients.Add(new CanFoodIngredient
                            {
                                CanFoodId = model.Id,
                            IngredientId = groupIngredient.IngredientId,
                                Count = groupIngredient.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    CanFood element = context.CanFoods.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.CanFoodIngredients.RemoveRange(context.CanFoodIngredients.Where(rec =>
                        rec.CanFoodId == id));
                        context.CanFoods.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
