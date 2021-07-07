namespace IceCreamShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redo : DbMigration
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
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        IceCreamOrderId = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        ShopName = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ShopId);
            
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
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Topping");
            DropTable("dbo.Shop");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IceCreamOrder");
            DropTable("dbo.Flavor");
            DropTable("dbo.Customer");
        }
    }
}
