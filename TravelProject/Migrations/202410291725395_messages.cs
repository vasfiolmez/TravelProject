namespace TravelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Content = c.String(),
                        SendDate = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        SenderAdminId = c.Int(nullable: false),
                        ReceiverAdminId = c.Int(nullable: false),
                        Admin_AdminId = c.Int(),
                        Admin_AdminId1 = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Admins", t => t.ReceiverAdminId)
                .ForeignKey("dbo.Admins", t => t.SenderAdminId)
                .ForeignKey("dbo.Admins", t => t.Admin_AdminId)
                .ForeignKey("dbo.Admins", t => t.Admin_AdminId1)
                .Index(t => t.SenderAdminId)
                .Index(t => t.ReceiverAdminId)
                .Index(t => t.Admin_AdminId)
                .Index(t => t.Admin_AdminId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Admin_AdminId1", "dbo.Admins");
            DropForeignKey("dbo.Messages", "Admin_AdminId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "SenderAdminId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "ReceiverAdminId", "dbo.Admins");
            DropIndex("dbo.Messages", new[] { "Admin_AdminId1" });
            DropIndex("dbo.Messages", new[] { "Admin_AdminId" });
            DropIndex("dbo.Messages", new[] { "ReceiverAdminId" });
            DropIndex("dbo.Messages", new[] { "SenderAdminId" });
            DropTable("dbo.Messages");
        }
    }
}
