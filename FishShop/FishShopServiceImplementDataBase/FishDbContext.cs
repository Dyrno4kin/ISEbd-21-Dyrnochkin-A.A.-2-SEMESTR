using FishShopModel;
using System.Data.Entity;

namespace FishShopServiceImplementDataBase
{
    public class FishDbContext : DbContext
    {
        public FishDbContext() : base("FishDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CanFood> CanFoods { get; set; }
        public virtual DbSet<CanFoodIngredient> CanFoodIngredients { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockIngredient> StockIngredients { get; set; }
        public virtual DbSet<Implementer> Implementers { get; set; }
    }
}
