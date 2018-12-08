namespace Task3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carriers",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfPosting = c.DateTime(nullable: false),
                        From = c.String(),
                        To = c.String(),
                        DateOfLoading = c.DateTime(nullable: false),
                        CarrierInfo_Name = c.String(maxLength: 128),
                        VehicleInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carriers", t => t.CarrierInfo_Name)
                .ForeignKey("dbo.Vehicles", t => t.VehicleInfo_Id)
                .Index(t => t.CarrierInfo_Name)
                .Index(t => t.VehicleInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "VehicleInfo_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Offers", "CarrierInfo_Name", "dbo.Carriers");
            DropForeignKey("dbo.Carriers", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Offers", new[] { "VehicleInfo_Id" });
            DropIndex("dbo.Offers", new[] { "CarrierInfo_Name" });
            DropIndex("dbo.Carriers", new[] { "Vehicle_Id" });
            DropTable("dbo.Offers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Carriers");
        }
    }
}
