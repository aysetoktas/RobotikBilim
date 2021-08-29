namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassroomDocuments",
                c => new
                    {
                        Classroom_ID = c.Int(nullable: false),
                        Document_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Classroom_ID, t.Document_ID })
                .ForeignKey("dbo.Classrooms", t => t.Classroom_ID, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.Document_ID, cascadeDelete: true)
                .Index(t => t.Classroom_ID)
                .Index(t => t.Document_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassroomDocuments", "Document_ID", "dbo.Documents");
            DropForeignKey("dbo.ClassroomDocuments", "Classroom_ID", "dbo.Classrooms");
            DropIndex("dbo.ClassroomDocuments", new[] { "Document_ID" });
            DropIndex("dbo.ClassroomDocuments", new[] { "Classroom_ID" });
            DropTable("dbo.ClassroomDocuments");
        }
    }
}
