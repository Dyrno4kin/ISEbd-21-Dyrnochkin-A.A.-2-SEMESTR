﻿namespace FishShopModel
{
    public class CanFoodIngredient
    {
        public int Id { get; set; }
        public int CanFoodId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual CanFood CanFood { get; set; }
    }
}
