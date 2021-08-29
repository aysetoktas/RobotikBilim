namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classroom : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classrooms", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Classroom_ID", "dbo.Classrooms");
            DropForeignKey("dbo.Users", "ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Classrooms", new[] { "User_ID" });
            DropIndex("dbo.Users", new[] { "ClassroomID" });
            DropIndex("dbo.Users", new[] { "Classroom_ID" });
            DropColumn("dbo.Users", "ClassroomID");
            RenameColumn(table: "dbo.Users", name: "Classroom_ID", newName: "ClassroomID");
            AlterColumn("dbo.Users", "ClassroomID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "ClassroomID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "ClassroomID");
            AddForeignKey("dbo.Users", "ClassroomID", "dbo.Classrooms", "ID", cascadeDelete: true);
            DropColumn("dbo.Classrooms", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classrooms", "User_ID", c => c.Int());
            DropForeignKey("dbo.Users", "ClassroomID", "dbo.Classrooms");
            DropIndex("dbo.Users", new[] { "ClassroomID" });
            AlterColumn("dbo.Users", "ClassroomID", c => c.Int());
            AlterColumn("dbo.Users", "ClassroomID", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "ClassroomID", newName: "Classroom_ID");
            AddColumn("dbo.Users", "ClassroomID", c => c.Int());
            CreateIndex("dbo.Users", "Classroom_ID");
            CreateIndex("dbo.Users", "ClassroomID");
            CreateIndex("dbo.Classrooms", "User_ID");
            AddForeignKey("dbo.Users", "ClassroomID", "dbo.Classrooms", "ID");
            AddForeignKey("dbo.Users", "Classroom_ID", "dbo.Classrooms", "ID");
            AddForeignKey("dbo.Classrooms", "User_ID", "dbo.Users", "ID");
        }
    }
}
