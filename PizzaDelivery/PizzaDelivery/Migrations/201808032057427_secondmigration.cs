namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Employees", "OrderId", "dbo.Orders");
            DropIndex("dbo.Customers", new[] { "OrderId" });
            DropIndex("dbo.Employees", new[] { "OrderId" });
            AddColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "OrderId");
            CreateIndex("dbo.Orders", "UserId");
            CreateIndex("dbo.Employees", "OrderId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Customers", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "OrderId" });
            AlterColumn("dbo.Employees", "OrderId", c => c.Int());
            AlterColumn("dbo.Customers", "OrderId", c => c.Int());
            DropColumn("dbo.Orders", "UserId");
            CreateIndex("dbo.Employees", "OrderId");
            CreateIndex("dbo.Customers", "OrderId");
            AddForeignKey("dbo.Employees", "OrderId", "dbo.Orders", "Id");
            AddForeignKey("dbo.Customers", "OrderId", "dbo.Orders", "Id");
        }
    }
}
