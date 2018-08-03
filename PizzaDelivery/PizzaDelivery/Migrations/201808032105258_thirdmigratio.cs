namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigratio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "OrderId", "dbo.Orders");
            DropIndex("dbo.Customers", new[] { "OrderId" });
            AlterColumn("dbo.Customers", "OrderId", c => c.Int());
            CreateIndex("dbo.Customers", "OrderId");
            AddForeignKey("dbo.Customers", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "OrderId", "dbo.Orders");
            DropIndex("dbo.Customers", new[] { "OrderId" });
            AlterColumn("dbo.Customers", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "OrderId");
            AddForeignKey("dbo.Customers", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
