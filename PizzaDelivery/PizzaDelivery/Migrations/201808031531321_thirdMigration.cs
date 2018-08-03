namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Managers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "UserId");
            CreateIndex("dbo.Employees", "UserId");
            CreateIndex("dbo.Managers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Managers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Managers", new[] { "UserId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropColumn("dbo.Managers", "UserId");
            DropColumn("dbo.Employees", "UserId");
            DropColumn("dbo.Customers", "UserId");
        }
    }
}
