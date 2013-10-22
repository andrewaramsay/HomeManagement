namespace HomeManagement.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pumpings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Milliliters = c.Int(),
                        BreastfeedingAttempt = c.Boolean(),
                        BreastfeedingComments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PumpingTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                        PumpingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pumpings", t => t.PumpingId, cascadeDelete: true)
                .Index(t => t.PumpingId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateEntered = c.DateTime(nullable: false),
                        DateAssigned = c.DateTime(),
                        DateCompleted = c.DateTime(),
                        PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tasks", new[] { "PersonId" });
            DropIndex("dbo.PumpingTimes", new[] { "PumpingId" });
            DropForeignKey("dbo.Tasks", "PersonId", "dbo.People");
            DropForeignKey("dbo.PumpingTimes", "PumpingId", "dbo.Pumpings");
            DropTable("dbo.Tasks");
            DropTable("dbo.People");
            DropTable("dbo.PumpingTimes");
            DropTable("dbo.Pumpings");
        }
    }
}
