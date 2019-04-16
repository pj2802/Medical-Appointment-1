namespace PatientApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        BP = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Temperature = c.Int(nullable: false),
                        DoctorName = c.String(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false, maxLength: 255),
                        Gender = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        MaritalStatus = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "PatientID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
        }
    }
}
