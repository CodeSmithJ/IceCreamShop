namespace IceCreamShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkingMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.IceCreamOrder", "ICFlavor");
            DropColumn("dbo.IceCreamOrder", "ICTopping");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IceCreamOrder", "ICTopping", c => c.Int(nullable: false));
            AddColumn("dbo.IceCreamOrder", "ICFlavor", c => c.Int(nullable: false));
        }
    }
}
