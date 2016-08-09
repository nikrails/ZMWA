namespace ZMWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePaths : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "PostResume_ID", "dbo.PostResumes");
            DropIndex("dbo.Files", new[] { "PostResume_ID" });
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PostResumeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.PostResumes", t => t.PostResumeID, cascadeDelete: true)
                .Index(t => t.PostResumeID);
            
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        PostResume_ID = c.Int(),
                    })
                .PrimaryKey(t => t.FileId);
            
            DropForeignKey("dbo.FilePaths", "PostResumeID", "dbo.PostResumes");
            DropIndex("dbo.FilePaths", new[] { "PostResumeID" });
            DropTable("dbo.FilePaths");
            CreateIndex("dbo.Files", "PostResume_ID");
            AddForeignKey("dbo.Files", "PostResume_ID", "dbo.PostResumes", "ID");
        }
    }
}
