using FishShopModel;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishShopServiceImplement.Implementations
{
    public class CanFoodServiceDB : ICanFoodService
    {
        private DataListSingleton source;
        public CanFoodServiceDB()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<CanFoodViewModel> GetList()
        {
            List<CanFoodViewModel> result = source.CanFoods.Select(rec => new CanFoodViewModel
            {
                Id = rec.Id,
                CanFoodName = rec.CanFoodName,
                Price = rec.Price,
                CanFoodIngredients = source.CanFoodIngredients
                    .Where(recCI => recCI.CanFoodId == rec.Id)
                    .Select(recCI => new CanFoodIngredientViewModel
                    {
                        Id = recCI.Id,
                        CanFoodId = recCI.CanFoodId,
                        IngredientId = recCI.IngredientId,
                        IngredientName = source.Ingredients.FirstOrDefault(recI =>
    recI.Id == recCI.IngredientId)?.IngredientName,
                        Count = recCI.Count
                    })
                    .ToList()
            })
            .ToList();
            return result;
        }
        public CanFoodViewModel GetElement(int id)
        {
            CanFood element = source.CanFoods.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CanFoodViewModel
                {
                    Id = element.Id,
                    CanFoodName = element.CanFoodName,
                    Price = element.Price,
                    CanFoodIngredients = source.CanFoodIngredients
                .Where(recCI => recCI.CanFoodId == element.Id)
                .Select(recCI => new CanFoodIngredientViewModel
                {
                    Id = recCI.Id,
                    CanFoodId = recCI.CanFoodId,
                    IngredientId = recCI.IngredientId,
                    IngredientName = source.Ingredients.FirstOrDefault(recI =>
     recI.Id == recCI.IngredientId)?.IngredientName,
                    Count = recCI.Count
                })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CanFoodBindingModel model)
        {
            CanFood element = source.CanFoods.FirstOrDefault(rec => rec.CanFoodName ==
 model.CanFoodName);
            if (element != null)
            {
                throw new Exception("Уже есть консерва с таким названием");
            }
            int maxId = source.CanFoods.Count > 0 ? source.CanFoods.Max(rec => rec.Id) :
           0;
            source.CanFoods.Add(new CanFood
            {
                Id = maxId + 1,
                CanFoodName = model.CanFoodName,
                Price = model.Price
            });
            // компоненты для консерв
            int maxCIId = source.CanFoodIngredients.Count > 0 ?
           source.CanFoodIngredients.Max(rec => rec.Id) : 0;
            // убираем дубли по ингредиентам
            var groupIngredients = model.CanFoodIngredients
            .GroupBy(rec => rec.IngredientId)
           .Select(rec => new
           {
               IngredientId = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            // добавляем ингредиаенты
            foreach (var groupIngredient in groupIngredients)
            {
                source.CanFoodIngredients.Add(new CanFoodIngredient
                {
                    Id = ++maxCIId,
                    CanFoodId = maxId + 1,
                    IngredientId = groupIngredient.IngredientId,
                    Count = groupIngredient.Count
                });
            }
        }
        public void UpdElement(CanFoodBindingModel model)
        {
            CanFood element = source.CanFoods.FirstOrDefault(rec => rec.CanFoodName ==
 model.CanFoodName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть консерва с таким названием");
            }
            element = source.CanFoods.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.CanFoodName = model.CanFoodName;
            element.Price = model.Price;
            int maxCIId = source.CanFoodIngredients.Count > 0 ?
           source.CanFoodIngredients.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var ingrIds = model.CanFoodIngredients.Select(rec =>
           rec.IngredientId).Distinct();
            var updateIngredients = source.CanFoodIngredients.Where(rec => rec.CanFoodId ==
           model.Id && ingrIds.Contains(rec.IngredientId));
            foreach (var updateIngredient in updateIngredients)
            {
                updateIngredient.Count = model.CanFoodIngredients.FirstOrDefault(rec =>
               rec.Id == updateIngredient.Id).Count;
            }
            source.CanFoodIngredients.RemoveAll(rec => rec.CanFoodId == model.Id &&
           !ingrIds.Contains(rec.IngredientId));
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
                CanFoodIngredient elementCI = source.CanFoodIngredients.FirstOrDefault(rec
               => rec.CanFoodId == model.Id && rec.IngredientId == groupIngredient.IngredientId);
                if (elementCI != null)
                {
                    elementCI.Count += groupIngredient.Count;
                }
                else
                {
                    source.CanFoodIngredients.Add(new CanFoodIngredient
                    {
                        Id = ++maxCIId,
                        CanFoodId = model.Id,
                        IngredientId = groupIngredient.IngredientId,
                        Count = groupIngredient.Count
                    });
                }
            }
        }
        public void DelElement(int id)
        {
            CanFood element = source.CanFoods.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.CanFoodIngredients.RemoveAll(rec => rec.CanFoodId == id);
                source.CanFoods.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
