namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Students", new[] { "ClassroomID" });
            CreateTable(
                "dbo.StudentClassrooms",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Classroom_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Classroom_ID })
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => t.Classroom_ID, cascadeDelete: true)
                .Index(t => t.Student_ID)
                .Index(t => t.Classroom_ID);
            
            DropColumn("dbo.Students", "ClassroomID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ClassroomID", c => c.Int());
            DropForeignKey("dbo.StudentClassrooms", "Classroom_ID", "dbo.Classrooms");
            DropForeignKey("dbo.StudentClassrooms", "Student_ID", "dbo.Students");
            DropIndex("dbo.StudentClassrooms", new[] { "Classroom_ID" });
            DropIndex("dbo.StudentClassrooms", new[] { "Student_ID" });
            DropTable("dbo.StudentClassrooms");
            CreateIndex("dbo.Students", "ClassroomID");
            AddForeignKey("dbo.Students", "ClassroomID", "dbo.Classrooms", "ID");
        }
    }
}
