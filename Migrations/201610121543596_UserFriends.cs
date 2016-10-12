namespace PostProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFriends : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FriendsIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FriendsIds");
        }
    }
}
