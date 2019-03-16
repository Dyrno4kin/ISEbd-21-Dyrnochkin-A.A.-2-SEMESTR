using System;

namespace FishShopModel
{
    /// <summary>
    /// Заказ заказчика
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CanFoodId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
