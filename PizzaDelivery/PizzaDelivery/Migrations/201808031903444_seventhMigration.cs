namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventhMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "MenuId", "dbo.Menus");
            DropIndex("dbo.Orders", new[] { "MenuId" });
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.CustomerId);
            
            DropColumn("dbo.Orders", "MenuId");
            DropTable("dbo.Menus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "MenuId", c => c.Int());
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderItems", new[] { "CustomerId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.OrderItems");
            CreateIndex("dbo.Orders", "MenuId");
            AddForeignKey("dbo.Orders", "MenuId", "dbo.Menus", "Id");
        }
    }
}
