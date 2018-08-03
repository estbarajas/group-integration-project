namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "ItemId", "dbo.Items");
            DropIndex("dbo.Menus", new[] { "ItemId" });
            DropColumn("dbo.Menus", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "ItemId", c => c.Int());
            CreateIndex("dbo.Menus", "ItemId");
            AddForeignKey("dbo.Menus", "ItemId", "dbo.Items", "Id");
        }
    }
}
