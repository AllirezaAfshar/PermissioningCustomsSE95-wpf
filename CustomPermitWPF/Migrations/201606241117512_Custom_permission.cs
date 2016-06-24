namespace CustomPermitWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Custom_permission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permission_Rule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PermissionID = c.Int(nullable: false),
                        RuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rules", t => t.RuleID, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.PermissionID, cascadeDelete: true)
                .Index(t => t.PermissionID)
                .Index(t => t.RuleID);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permission_Rule", "PermissionID", "dbo.Permissions");
            DropForeignKey("dbo.Permission_Rule", "RuleID", "dbo.Rules");
            DropIndex("dbo.Permission_Rule", new[] { "RuleID" });
            DropIndex("dbo.Permission_Rule", new[] { "PermissionID" });
            DropTable("dbo.Rules");
            DropTable("dbo.Permission_Rule");
        }
    }
}
