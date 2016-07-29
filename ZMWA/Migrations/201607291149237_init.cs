namespace ZMWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Mobile = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostResumes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dob = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        PinCode = c.Int(nullable: false),
                        LastEmployer = c.String(),
                        Experience = c.Int(nullable: false),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostResumes");
            DropTable("dbo.Contacts");
        }
    }
}
