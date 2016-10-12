namespace PostProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EducationPlace", c => c.String());
            AddColumn("dbo.AspNetUsers", "NativeTown", c => c.String());
            AddColumn("dbo.AspNetUsers", "Hobby", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Hobby");
            DropColumn("dbo.AspNetUsers", "NativeTown");
            DropColumn("dbo.AspNetUsers", "EducationPlace");
            DropColumn("dbo.AspNetUsers", "Age");
        }
    }
}
