namespace ZMWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "PostResumeID", "dbo.PostResumes");
            DropIndex("dbo.Files", new[] { "PostResumeID" });
            RenameColumn(table: "dbo.Files", name: "PostResumeID", newName: "PostResume_ID");
            AddColumn("dbo.Files", "PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "PostResume_ID", c => c.Int());
            CreateIndex("dbo.Files", "PostResume_ID");
            AddForeignKey("dbo.Files", "PostResume_ID", "dbo.PostResumes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "PostResume_ID", "dbo.PostResumes");
            DropIndex("dbo.Files", new[] { "PostResume_ID" });
            AlterColumn("dbo.Files", "PostResume_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Files", "PersonId");
            RenameColumn(table: "dbo.Files", name: "PostResume_ID", newName: "PostResumeID");
            CreateIndex("dbo.Files", "PostResumeID");
            AddForeignKey("dbo.Files", "PostResumeID", "dbo.PostResumes", "ID", cascadeDelete: true);
        }
    }
}
