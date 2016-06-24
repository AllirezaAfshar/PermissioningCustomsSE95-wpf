namespace CustomPermitWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commodity_Types",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        value = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Declerations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        CommodityName = c.String(),
                        Price = c.Int(nullable: false),
                        CountryOrigin = c.String(),
                        RecordDateTime = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        CommodityType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Commodity_Types", t => t.CommodityType_ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CommodityType_ID);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinistryID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ministries", t => t.MinistryID, cascadeDelete: true)
                .ForeignKey("dbo.Declerations", t => t.DocumentID, cascadeDelete: true)
                .Index(t => t.MinistryID)
                .Index(t => t.DocumentID);
            
            CreateTable(
                "dbo.Ministries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Declerations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Permissions", "DocumentID", "dbo.Declerations");
            DropForeignKey("dbo.Permissions", "MinistryID", "dbo.Ministries");
            DropForeignKey("dbo.Declerations", "CommodityType_ID", "dbo.Commodity_Types");
            DropIndex("dbo.Permissions", new[] { "DocumentID" });
            DropIndex("dbo.Permissions", new[] { "MinistryID" });
            DropIndex("dbo.Declerations", new[] { "CommodityType_ID" });
            DropIndex("dbo.Declerations", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Ministries");
            DropTable("dbo.Permissions");
            DropTable("dbo.Declerations");
            DropTable("dbo.Commodity_Types");
        }
    }
}
