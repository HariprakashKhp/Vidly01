namespace Vidly01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembeshipTypes SET Name='Pay As you go' WHERE Id = 1");
            Sql("UPDATE MembeshipTypes SET Name='Monthly' WHERE Id = 2");
            Sql("UPDATE MembeshipTypes SET Name='Quarterly' WHERE Id = 3");
            Sql("UPDATE MembeshipTypes SET Name='Annually' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
