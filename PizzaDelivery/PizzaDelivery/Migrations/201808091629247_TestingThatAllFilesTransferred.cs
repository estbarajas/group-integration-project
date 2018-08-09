namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingThatAllFilesTransferred : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailAPIs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ToEmailAddress = c.String(),
                        FromEmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TextAPIs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SendToPhoneNumber = c.String(),
                        SendFromPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TextAPIs");
            DropTable("dbo.EmailAPIs");
        }
    }
}
