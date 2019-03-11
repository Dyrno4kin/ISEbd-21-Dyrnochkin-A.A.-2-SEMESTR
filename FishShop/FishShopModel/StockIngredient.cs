﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopModel
{
    /// <summary>
    /// Сколько ингредиентов хранится на складе
    /// </summary>
    public class StockIngredient
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
