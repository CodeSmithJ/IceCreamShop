namespace IceCreamShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderView", "ToppingName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderView", "ToppingName");
        }
    }
}
