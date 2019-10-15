namespace MVC_Application1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembership : DbMigration
    {
        public override void Up()
        {
            Sql("insert MembershipType1(Type,Duration,SignUpFree,Discount)values('Yearly',12,1234,20)");
            Sql("insert MembershipType1(Type,Duration,SignUpFree,Discount)values('Half-Yearly',16,754,80)");
            Sql("insert MembershipType1(Type,Duration,SignUpFree,Discount)values('Quarterly',17,8976,25)");
        }
        
        public override void Down()
        {
        }
    }
}
