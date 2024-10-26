namespace TravelProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 100),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DayNight = c.Int(nullable: false),
                        SliderImageUrl = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Capacity = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DestinationId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.TourCityImages",
                c => new
                    {
                        TourCityImageId = c.Int(nullable: false, identity: true),
                        CityImage = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TourCityImageId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        MapLocation = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(),
                        ReceiverMail = c.String(),
                        Subject = c.String(),
                        Content = c.String(),
                        SendDate = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        PersonCount = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ReservationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourCityImages", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Destinations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.TourCityImages", new[] { "CityId" });
            DropIndex("dbo.Destinations", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Messages");
            DropTable("dbo.Contacts");
            DropTable("dbo.TourCityImages");
            DropTable("dbo.Destinations");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
