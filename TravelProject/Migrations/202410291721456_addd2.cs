namespace TravelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "ReceiverAdminId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "SenderAdminId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "Admin_AdminId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "Admin_AdminId1", "dbo.Admins");
            DropIndex("dbo.Messages", new[] { "SenderAdminId" });
            DropIndex("dbo.Messages", new[] { "ReceiverAdminId" });
            DropIndex("dbo.Messages", new[] { "Admin_AdminId" });
            DropIndex("dbo.Messages", new[] { "Admin_AdminId1" });
            DropTable("dbo.Messages");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.MessageId);
            
            CreateIndex("dbo.Messages", "Admin_AdminId1");
            CreateIndex("dbo.Messages", "Admin_AdminId");
            CreateIndex("dbo.Messages", "ReceiverAdminId");
            CreateIndex("dbo.Messages", "SenderAdminId");
            AddForeignKey("dbo.Messages", "Admin_AdminId1", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.Messages", "Admin_AdminId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.Messages", "SenderAdminId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.Messages", "ReceiverAdminId", "dbo.Admins", "AdminId");
        }
    }
}
