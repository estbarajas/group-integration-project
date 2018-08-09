namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingErrors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StripeAPIs",
                c => new
                    {
                        stripePublishKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.stripePublishKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StripeAPIs");
        }
    }
}
