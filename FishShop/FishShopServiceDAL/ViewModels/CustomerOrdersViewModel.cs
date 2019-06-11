namespace FishShopServiceDAL.ViewModels
{
    public class CustomerOrdersViewModel
    {
        public string CustomerName { get; set; }
        public string DateCreate { get; set; }
        public string CanFoodName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}