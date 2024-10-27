namespace TravelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TourcityImage_mapLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourCityImages", "MapLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourCityImages", "MapLocation");
        }
    }
}
