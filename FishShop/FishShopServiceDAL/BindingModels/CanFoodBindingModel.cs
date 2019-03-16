﻿using System.Collections.Generic;

namespace FishShopServiceDAL.BindingModels
{
    /// <summary>
    /// Консерва, изготавливаемая на заводе
    /// </summary>
    public class CanFoodBindingModel
    {
        public int Id { get; set; }
        public string CanFoodName { get; set; }
        public decimal Price { get; set; }
        public List<CanFoodIngredientBindingModel> CanFoodIngredients { get; set; }
    }
}
