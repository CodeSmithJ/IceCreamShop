namespace IceCreamShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthRedo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IceCreamOrder", "ICFlavor", c => c.Int(nullable: false));
            AddColumn("dbo.IceCreamOrder", "ICTopping", c => c.Int(nullable: false));
            AddColumn("dbo.Topping", "ICTopping", c => c.Int(nullable: false));
            CreateIndex("dbo.IceCreamOrder", "FlavorId");
            CreateIndex("dbo.IceCreamOrder", "ToppingsId");
            CreateIndex("dbo.IceCreamOrder", "CustomerId");
            AddForeignKey("dbo.IceCreamOrder", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.IceCreamOrder", "FlavorId", "dbo.Flavor", "FlavorId", cascadeDelete: true);
            AddForeignKey("dbo.IceCreamOrder", "ToppingsId", "dbo.Topping", "ToppingId", cascadeDelete: true);
            DropColumn("dbo.Topping", "ICToppings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topping", "ICToppings", c => c.Int(nullable: false));
            DropForeignKey("dbo.IceCreamOrder", "ToppingsId", "dbo.Topping");
            DropForeignKey("dbo.IceCreamOrder", "FlavorId", "dbo.Flavor");
            DropForeignKey("dbo.IceCreamOrder", "CustomerId", "dbo.Customer");
            DropIndex("dbo.IceCreamOrder", new[] { "CustomerId" });
            DropIndex("dbo.IceCreamOrder", new[] { "ToppingsId" });
            DropIndex("dbo.IceCreamOrder", new[] { "FlavorId" });
            DropColumn("dbo.Topping", "ICTopping");
            DropColumn("dbo.IceCreamOrder", "ICTopping");
            DropColumn("dbo.IceCreamOrder", "ICFlavor");
        }
    }
}
