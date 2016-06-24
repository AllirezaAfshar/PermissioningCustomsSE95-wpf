namespace CustomPermitWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decl_commodity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Declerations", "CommodityType_ID", "dbo.Commodity_Types");
            DropForeignKey("dbo.Declerations", "UserID", "dbo.Users");
            DropIndex("dbo.Declerations", new[] { "UserID" });
            DropIndex("dbo.Declerations", new[] { "CommodityType_ID" });
            RenameColumn(table: "dbo.Declerations", name: "CommodityType_ID", newName: "CommodityTypeId");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Declerations", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Declerations", "CommodityTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String());
            AddPrimaryKey("dbo.Users", "ID");
            CreateIndex("dbo.Declerations", "UserID");
            CreateIndex("dbo.Declerations", "CommodityTypeId");
            AddForeignKey("dbo.Declerations", "CommodityTypeId", "dbo.Commodity_Types", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Declerations", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Declerations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Declerations", "CommodityTypeId", "dbo.Commodity_Types");
            DropIndex("dbo.Declerations", new[] { "CommodityTypeId" });
            DropIndex("dbo.Declerations", new[] { "UserID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Declerations", "CommodityTypeId", c => c.Int());
            AlterColumn("dbo.Declerations", "UserID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Users", "ID");
            AddPrimaryKey("dbo.Users", "Username");
            RenameColumn(table: "dbo.Declerations", name: "CommodityTypeId", newName: "CommodityType_ID");
            CreateIndex("dbo.Declerations", "CommodityType_ID");
            CreateIndex("dbo.Declerations", "UserID");
            AddForeignKey("dbo.Declerations", "UserID", "dbo.Users", "Username", cascadeDelete: true);
            AddForeignKey("dbo.Declerations", "CommodityType_ID", "dbo.Commodity_Types", "ID");
        }
    }
}
