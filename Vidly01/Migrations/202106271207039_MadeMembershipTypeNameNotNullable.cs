namespace Vidly01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeMembershipTypeNameNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembeshipTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembeshipTypes", "Name", c => c.String());
        }
    }
}
