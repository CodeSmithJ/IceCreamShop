namespace IceCreamShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerGuid = c.Guid(nullable: false),
                        CustomerName = c.String(),
                        Payment = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Flavor",
                c => new
                    {
                        FlavorId = c.Int(nullable: false, identity: true),
                        ICFlavor = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        FlavorName = c.String(),
                    })
                .PrimaryKey(t => t.FlavorId);
            
            CreateTable(
                "dbo.IceCreamOrder",
                c => new
                    {
                        IceCreamOrderId = c.Int(nullable: false, identity: true),
                        FlavorId = c.Int(nullable: false),
                        ToppingsId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IceCreamOrderId);
            
            CreateTable(
                "dbo.Topping",
                c => new
                    {
                        ToppingId = c.Int(nullable: false, identity: true),
                        ToppingName = c.String(),
                        Price = c.Double(nullable: false),
                        ICToppings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToppingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Topping");
            DropTable("dbo.IceCreamOrder");
            DropTable("dbo.Flavor");
            DropTable("dbo.Customer");
        }
    }
}
