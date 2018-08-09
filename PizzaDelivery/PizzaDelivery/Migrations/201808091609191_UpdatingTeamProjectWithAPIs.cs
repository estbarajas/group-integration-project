namespace PizzaDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingTeamProjectWithAPIs : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EmailAPIs");
            DropTable("dbo.TextAPIs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TextAPIs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SendToPhoneNumber = c.String(),
                        SendFromPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmailAPIs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ToEmailAddress = c.String(),
                        FromEmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
