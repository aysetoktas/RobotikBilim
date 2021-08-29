namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ClassroomID", "dbo.Classrooms");
            DropForeignKey("dbo.EducationUsers", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.EducationUsers", "User_ID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "ClassroomID" });
            DropIndex("dbo.EducationUsers", new[] { "Education_ID" });
            DropIndex("dbo.EducationUsers", new[] { "User_ID" });
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ClassroomID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomID)
                .Index(t => t.ClassroomID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "Education_ID", c => c.Int());
            CreateIndex("dbo.Users", "Education_ID");
            AddForeignKey("dbo.Users", "Education_ID", "dbo.Educations", "ID");
            DropColumn("dbo.Users", "ClassroomID");
            DropTable("dbo.EducationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EducationUsers",
                c => new
                    {
                        Education_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_ID, t.User_ID });
            
            AddColumn("dbo.Users", "ClassroomID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "Education_ID", "dbo.Educations");
            DropForeignKey("dbo.Students", "ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Users", new[] { "Education_ID" });
            DropIndex("dbo.Students", new[] { "ClassroomID" });
            DropColumn("dbo.Users", "Education_ID");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Admins");
            CreateIndex("dbo.EducationUsers", "User_ID");
            CreateIndex("dbo.EducationUsers", "Education_ID");
            CreateIndex("dbo.Users", "ClassroomID");
            AddForeignKey("dbo.EducationUsers", "User_ID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EducationUsers", "Education_ID", "dbo.Educations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "ClassroomID", "dbo.Classrooms", "ID", cascadeDelete: true);
        }
    }
}
