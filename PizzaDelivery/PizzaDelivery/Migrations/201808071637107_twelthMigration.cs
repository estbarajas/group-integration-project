namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twelthMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropColumn("dbo.Employees", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "UserId");
            AddForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
