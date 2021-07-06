namespace Vidly01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembeshipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignupFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembeshipType_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembeshipType_Id");
            AddForeignKey("dbo.Customers", "MembeshipType_Id", "dbo.MembeshipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembeshipType_Id", "dbo.MembeshipTypes");
            DropIndex("dbo.Customers", new[] { "MembeshipType_Id" });
            DropColumn("dbo.Customers", "MembeshipType_Id");
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropTable("dbo.MembeshipTypes");
        }
    }
}
