namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "OrderId", "dbo.Orders");
            DropIndex("dbo.Employees", new[] { "OrderId" });
            AlterColumn("dbo.Employees", "OrderId", c => c.Int());
            CreateIndex("dbo.Employees", "OrderId");
            AddForeignKey("dbo.Employees", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "OrderId", "dbo.Orders");
            DropIndex("dbo.Employees", new[] { "OrderId" });
            AlterColumn("dbo.Employees", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "OrderId");
            AddForeignKey("dbo.Employees", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
