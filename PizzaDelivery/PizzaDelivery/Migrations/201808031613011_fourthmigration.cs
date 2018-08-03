namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Managers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "Email", c => c.String());
            AddColumn("dbo.Employees", "Email", c => c.String());
        }
    }
}
