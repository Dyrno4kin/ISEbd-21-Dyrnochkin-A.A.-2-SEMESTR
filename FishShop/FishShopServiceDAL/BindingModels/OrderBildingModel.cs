﻿namespace FishShopServiceDAL.BindingModels
{
  public class OrderBindingModel
  {
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CanFoodId { get; set; }
    public int Count { get; set; }
    public decimal Sum { get; set; }
  }
}
