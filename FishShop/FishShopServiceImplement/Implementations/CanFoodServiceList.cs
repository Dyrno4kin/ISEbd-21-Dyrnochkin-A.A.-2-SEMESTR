using FishShopModel;
using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
namespace FishShopServiceImplement.Implementations
{
    public class CanFoodServiceList : ICanFoodService
    {
        private DataListSingleton source;
        public CanFoodServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<CanFoodViewModel> GetList()
        {
            List<CanFoodViewModel> result = new List<CanFoodViewModel>();
            for (int i = 0; i < source.CanFoods.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<CanFoodIngredientViewModel> canFoodIngredients = new
List<CanFoodIngredientViewModel>();
                for (int j = 0; j < source.CanFoodIngredients.Count; ++j)
                {
                    if (source.CanFoodIngredients[j].CanFoodId == source.CanFoods[i].Id)
                    {
                        string ingredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.CanFoodIngredients[j].IngredientId ==
                           source.CanFoods[k].Id)
                            {
                                ingredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        canFoodIngredients.Add(new CanFoodIngredientViewModel
                        {
                            Id = source.CanFoodIngredients[j].Id,
                            CanFoodId = source.CanFoodIngredients[j].CanFoodId,
                            IngredientId = source.CanFoodIngredients[j].IngredientId,
                            IngredientName = ingredientName,
                            Count = source.CanFoodIngredients[j].Count
                        });
                    }
                }
                result.Add(new CanFoodViewModel
                {
                    Id = source.CanFoods[i].Id,
                    CanFoodName = source.CanFoods[i].CanFoodName,
                    Price = source.CanFoods[i].Price,
                    CanFoodIngredients = canFoodIngredients
                });
            }
            return result;
        }
        public CanFoodViewModel GetElement(int id)
        {
            for (int i = 0; i < source.CanFoods.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<CanFoodIngredientViewModel> canFoodIngredients = new
List<CanFoodIngredientViewModel>();
                for (int j = 0; j < source.CanFoodIngredients.Count; ++j)
                {
                    if (source.CanFoodIngredients[j].CanFoodId == source.CanFoods[i].Id)
                    {
                        string ingredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.CanFoodIngredients[j].IngredientId ==
                           source.Ingredients[k].Id)
                            {
                                ingredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        canFoodIngredients.Add(new CanFoodIngredientViewModel
                        {
                            Id = source.CanFoodIngredients[j].Id,
                            CanFoodId = source.CanFoodIngredients[j].CanFoodId,
                            IngredientId = source.CanFoodIngredients[j].IngredientId,
                            IngredientName = ingredientName,
                            Count = source.CanFoodIngredients[j].Count
                        });
                    }
                }
                if (source.CanFoods[i].Id == id)
                {
                    return new CanFoodViewModel
                    {
                        Id = source.CanFoods[i].Id,
                        CanFoodName = source.CanFoods[i].CanFoodName,
                        Price = source.CanFoods[i].Price,
                        CanFoodIngredients = canFoodIngredients
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CanFoodBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.CanFoods.Count; ++i)
            {
                if (source.CanFoods[i].Id > maxId)
                {
                    maxId = source.CanFoods[i].Id;
                }
                if (source.CanFoods[i].CanFoodName == model.CanFoodName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.CanFoods.Add(new CanFood
            {
                Id = maxId + 1,
                CanFoodName = model.CanFoodName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxCIId = 0;
            for (int i = 0; i < source.CanFoodIngredients.Count; ++i)
            {
                if (source.CanFoodIngredients[i].Id > maxCIId)
                {
                    maxCIId = source.CanFoodIngredients[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.CanFoodIngredients.Count; ++i)
            {
                for (int j = 1; j < model.CanFoodIngredients.Count; ++j)
                {
                    if (model.CanFoodIngredients[i].CanFoodId ==
                    model.CanFoodIngredients[j].CanFoodId)
                    {
                        model.CanFoodIngredients[i].Count +=
                        model.CanFoodIngredients[j].Count;
                        model.CanFoodIngredients.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.CanFoodIngredients.Count; ++i)
            {
                source.CanFoodIngredients.Add(new CanFoodIngredient
                {
                    Id = ++maxCIId,
                    CanFoodId = maxId + 1,
                    IngredientId = model.CanFoodIngredients[i].IngredientId,
                    Count = model.CanFoodIngredients[i].Count
                });
            }
        }
        public void UpdElement(CanFoodBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.CanFoods.Count; ++i)
            {
                if (source.CanFoods[i].Id == model.Id)
                {
                index = i;
                }
                if (source.CanFoods[i].CanFoodName == model.CanFoodName &&
                source.CanFoods[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.CanFoods[index].CanFoodName = model.CanFoodName;
            source.CanFoods[index].Price = model.Price;
            int maxCIId = 0;
            for (int i = 0; i < source.CanFoodIngredients.Count; ++i)
            {
                if (source.CanFoodIngredients[i].Id > maxCIId)
                {
                    maxCIId = source.CanFoodIngredients[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.CanFoodIngredients.Count; ++i)
            {
                if (source.CanFoodIngredients[i].CanFoodId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.CanFoodIngredients.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.CanFoodIngredients[i].Id ==
                       model.CanFoodIngredients[j].Id)
                        {
                            source.CanFoodIngredients[i].Count =
                           model.CanFoodIngredients[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.CanFoodIngredients.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.CanFoodIngredients.Count; ++i)
            {
                if (model.CanFoodIngredients[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.CanFoodIngredients.Count; ++j)
                    {
                        if (source.CanFoodIngredients[j].CanFoodId == model.Id &&
                        source.CanFoodIngredients[j].IngredientId ==
                       model.CanFoodIngredients[i].IngredientId)
                        {
                            source.CanFoodIngredients[j].Count +=
                           model.CanFoodIngredients[i].Count;
                            model.CanFoodIngredients[i].Id =
                           source.CanFoodIngredients[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.CanFoodIngredients[i].Id == 0)
                    {
                        source.CanFoodIngredients.Add(new CanFoodIngredient
                        {
                            Id = ++maxCIId,
                            CanFoodId = model.Id,
                            IngredientId = model.CanFoodIngredients[i].IngredientId,
                            Count = model.CanFoodIngredients[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.CanFoodIngredients.Count; ++i)
            {
                if (source.CanFoodIngredients[i].CanFoodId == id)
                {
                    source.CanFoodIngredients.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.CanFoods.Count; ++i)
            {
                if (source.CanFoods[i].Id == id)
                {
                    source.CanFoods.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
