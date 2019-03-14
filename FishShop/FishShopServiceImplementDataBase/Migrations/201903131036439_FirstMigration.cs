namespace FishShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CanFoodIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CanFoodId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CanFoods", t => t.CanFoodId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.CanFoodId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.CanFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CanFoodName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CanFoodId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CanFoods", t => t.CanFoodId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CanFoodId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Stocks", t => t.StockId, cascadeDelete: true)
                .Index(t => t.StockId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockIngredients", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.StockIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.CanFoodIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CanFoodId", "dbo.CanFoods");
            DropForeignKey("dbo.CanFoodIngredients", "CanFoodId", "dbo.CanFoods");
            DropIndex("dbo.StockIngredients", new[] { "IngredientId" });
            DropIndex("dbo.StockIngredients", new[] { "StockId" });
            DropIndex("dbo.Orders", new[] { "CanFoodId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.CanFoodIngredients", new[] { "IngredientId" });
            DropIndex("dbo.CanFoodIngredients", new[] { "CanFoodId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.StockIngredients");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.CanFoods");
            DropTable("dbo.CanFoodIngredients");
        }
    }
}
