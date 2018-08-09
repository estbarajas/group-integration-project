namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedZipCodeFromIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Zipcode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Zipcode", c => c.Int(nullable: false));
        }
    }
}
