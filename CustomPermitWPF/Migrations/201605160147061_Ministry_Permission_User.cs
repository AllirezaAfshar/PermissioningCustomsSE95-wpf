namespace CustomPermitWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ministry_Permission_User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CommodityName = c.String(),
                        Price = c.Int(nullable: false),
                        CountryOrigin = c.String(),
                        RecordDateTime = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
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
                .ForeignKey("dbo.Documents", t => t.DocumentID, cascadeDelete: true)
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
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "UserID", "dbo.Users");
            DropForeignKey("dbo.Permissions", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Permissions", "MinistryID", "dbo.Ministries");
            DropIndex("dbo.Permissions", new[] { "DocumentID" });
            DropIndex("dbo.Permissions", new[] { "MinistryID" });
            DropIndex("dbo.Documents", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Ministries");
            DropTable("dbo.Permissions");
            DropTable("dbo.Documents");
        }
    }
}
