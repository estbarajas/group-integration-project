namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "OrderId", c => c.Int());
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropColumn("dbo.OrderItems", "OrderId");
        }
    }
}
