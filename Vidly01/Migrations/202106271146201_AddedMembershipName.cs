namespace Vidly01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembeshipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembeshipTypes", "Name");
        }
    }
}
