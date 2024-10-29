namespace TravelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderAdminId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "ReceiverAdminId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "ReceiverAdmin_AdminId", c => c.Int());
            AddColumn("dbo.Messages", "SenderAdmin_AdminId", c => c.Int());
            AddColumn("dbo.Messages", "Admin_AdminId", c => c.Int());
            AddColumn("dbo.Messages", "Admin_AdminId1", c => c.Int());
            CreateIndex("dbo.Messages", "ReceiverAdmin_AdminId");
            CreateIndex("dbo.Messages", "SenderAdmin_AdminId");
            CreateIndex("dbo.Messages", "Admin_AdminId");
            CreateIndex("dbo.Messages", "Admin_AdminId1");
            AddForeignKey("dbo.Messages", "ReceiverAdmin_AdminId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.Messages", "SenderAdmin_AdminId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.Messages", "Admin_AdminId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.Messages", "Admin_AdminId1", "dbo.Admins", "AdminId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Admin_AdminId1", "dbo.Admins");
            DropForeignKey("dbo.Messages", "Admin_AdminId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "SenderAdmin_AdminId", "dbo.Admins");
            DropForeignKey("dbo.Messages", "ReceiverAdmin_AdminId", "dbo.Admins");
            DropIndex("dbo.Messages", new[] { "Admin_AdminId1" });
            DropIndex("dbo.Messages", new[] { "Admin_AdminId" });
            DropIndex("dbo.Messages", new[] { "SenderAdmin_AdminId" });
            DropIndex("dbo.Messages", new[] { "ReceiverAdmin_AdminId" });
            DropColumn("dbo.Messages", "Admin_AdminId1");
            DropColumn("dbo.Messages", "Admin_AdminId");
            DropColumn("dbo.Messages", "SenderAdmin_AdminId");
            DropColumn("dbo.Messages", "ReceiverAdmin_AdminId");
            DropColumn("dbo.Messages", "ReceiverAdminId");
            DropColumn("dbo.Messages", "SenderAdminId");
        }
    }
}
