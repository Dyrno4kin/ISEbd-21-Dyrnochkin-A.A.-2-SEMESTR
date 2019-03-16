namespace FishShopServiceDAL.BindingModels
{
    public class CanFoodIngredientBindingModel
    {
        public int Id { get; set; }
        public int CanFoodId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
