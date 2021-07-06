namespace Vidly01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMembershipAndCustomerDetails : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MembeshipTypes", newName: "MembershipTypes");
            DropForeignKey("dbo.Customers", "MembeshipType_Id", "dbo.MembeshipTypes");
            DropIndex("dbo.Customers", new[] { "MembeshipType_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MembeshipType_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembeshipType_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembeshipType_Id");
            AddForeignKey("dbo.Customers", "MembeshipType_Id", "dbo.MembeshipTypes", "Id");
            RenameTable(name: "dbo.MembershipTypes", newName: "MembeshipTypes");
        }
    }
}
