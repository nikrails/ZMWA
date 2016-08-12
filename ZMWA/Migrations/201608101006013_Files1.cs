namespace ZMWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "PostResumeID", "dbo.PostResumes");
            DropIndex("dbo.FilePaths", new[] { "PostResumeID" });
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PostResumeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.PostResumes", t => t.PostResumeID, cascadeDelete: true)
                .Index(t => t.PostResumeID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.FilePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PostResumeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId);
            
            DropForeignKey("dbo.Files", "PostResumeID", "dbo.PostResumes");
            DropIndex("dbo.Files", new[] { "PostResumeID" });
            DropTable("dbo.Menus");
            DropTable("dbo.Files");
            CreateIndex("dbo.FilePaths", "PostResumeID");
            AddForeignKey("dbo.FilePaths", "PostResumeID", "dbo.PostResumes", "ID", cascadeDelete: true);
        }
    }
}
