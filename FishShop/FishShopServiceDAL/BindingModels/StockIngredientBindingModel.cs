namespace FishShopServiceDAL.BindingModels
{
    public class StockIngredientBindingModel
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}