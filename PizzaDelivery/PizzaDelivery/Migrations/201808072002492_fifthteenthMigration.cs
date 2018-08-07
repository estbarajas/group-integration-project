namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthteenthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "FutureDeliveryTime", c => c.String());
            DropColumn("dbo.Customers", "FutureDeliveryTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "FutureDeliveryTime", c => c.String());
            DropColumn("dbo.OrderItems", "FutureDeliveryTime");
        }
    }
}
