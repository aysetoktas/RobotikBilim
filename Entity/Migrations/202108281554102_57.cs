namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _57 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Path = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DocumentEducations",
                c => new
                    {
                        Document_ID = c.Int(nullable: false),
                        Education_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_ID, t.Education_ID })
                .ForeignKey("dbo.Documents", t => t.Document_ID, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_ID, cascadeDelete: true)
                .Index(t => t.Document_ID)
                .Index(t => t.Education_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentEducations", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.DocumentEducations", "Document_ID", "dbo.Documents");
            DropForeignKey("dbo.Documents", "CategoryID", "dbo.Categories");
            DropIndex("dbo.DocumentEducations", new[] { "Education_ID" });
            DropIndex("dbo.DocumentEducations", new[] { "Document_ID" });
            DropIndex("dbo.Documents", new[] { "CategoryID" });
            DropTable("dbo.DocumentEducations");
            DropTable("dbo.Categories");
            DropTable("dbo.Documents");
        }
    }
}
