namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _45 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherEducations",
                c => new
                    {
                        Teacher_ID = c.Int(nullable: false),
                        Education_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_ID, t.Education_ID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_ID, cascadeDelete: true)
                .Index(t => t.Teacher_ID)
                .Index(t => t.Education_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherEducations", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.TeacherEducations", "Teacher_ID", "dbo.Teachers");
            DropIndex("dbo.TeacherEducations", new[] { "Education_ID" });
            DropIndex("dbo.TeacherEducations", new[] { "Teacher_ID" });
            DropTable("dbo.TeacherEducations");
        }
    }
}
