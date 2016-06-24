namespace CustomPermitWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permissions", "DocumentID", "dbo.Declerations");
            DropIndex("dbo.Permissions", new[] { "DocumentID" });
            RenameColumn(table: "dbo.Permissions", name: "DocumentID", newName: "Decleration_ID");
            AlterColumn("dbo.Permissions", "Decleration_ID", c => c.Int());
            CreateIndex("dbo.Permissions", "Decleration_ID");
            AddForeignKey("dbo.Permissions", "Decleration_ID", "dbo.Declerations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "Decleration_ID", "dbo.Declerations");
            DropIndex("dbo.Permissions", new[] { "Decleration_ID" });
            AlterColumn("dbo.Permissions", "Decleration_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Permissions", name: "Decleration_ID", newName: "DocumentID");
            CreateIndex("dbo.Permissions", "DocumentID");
            AddForeignKey("dbo.Permissions", "DocumentID", "dbo.Declerations", "ID", cascadeDelete: true);
        }
    }
}
