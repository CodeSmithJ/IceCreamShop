namespace IceCreamShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shop", "ShopName", c => c.String(nullable: false));
            DropColumn("dbo.Shop", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shop", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.Shop", "ShopName");
        }
    }
}
