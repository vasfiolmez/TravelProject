namespace TravelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colDestination : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "TourStartLocationName", c => c.String());
            AddColumn("dbo.Destinations", "TourStartMapLocation", c => c.String());
            DropColumn("dbo.TourCityImages", "MapLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TourCityImages", "MapLocation", c => c.String());
            DropColumn("dbo.Destinations", "TourStartMapLocation");
            DropColumn("dbo.Destinations", "TourStartLocationName");
        }
    }
}
