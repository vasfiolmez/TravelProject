namespace TravelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class destinationReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "DestinationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "DestinationId");
            AddForeignKey("dbo.Reservations", "DestinationId", "dbo.Destinations", "DestinationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.Reservations", new[] { "DestinationId" });
            DropColumn("dbo.Reservations", "DestinationId");
        }
    }
}
