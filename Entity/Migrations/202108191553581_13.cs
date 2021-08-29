namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Educations", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Educations", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
