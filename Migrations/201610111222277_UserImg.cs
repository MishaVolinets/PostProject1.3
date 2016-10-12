namespace PostProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "srcPhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "srcPhoto");
        }
    }
}
