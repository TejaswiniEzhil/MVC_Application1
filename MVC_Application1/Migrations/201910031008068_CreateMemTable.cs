namespace MVC_Application1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipType1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Short(nullable: false),
                        SignUpFree = c.Double(nullable: false),
                        Discount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CustomerDetails", "MembershipType1Id", c => c.Int(nullable: true));
            CreateIndex("dbo.CustomerDetails", "MembershipType1Id");
            AddForeignKey("dbo.CustomerDetails", "MembershipType1Id", "dbo.MembershipType1", "Id", cascadeDelete: true);
            DropColumn("dbo.CustomerDetails", "City");
            DropTable("dbo.MembershipTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Short(nullable: false),
                        SignaUpFree = c.Double(nullable: false),
                        Discount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CustomerDetails", "City", c => c.String());
            DropForeignKey("dbo.CustomerDetails", "MembershipType1Id", "dbo.MembershipType1");
            DropIndex("dbo.CustomerDetails", new[] { "MembershipType1Id" });
            DropColumn("dbo.CustomerDetails", "MembershipType1Id");
            DropTable("dbo.MembershipType1");
        }
    }
}
