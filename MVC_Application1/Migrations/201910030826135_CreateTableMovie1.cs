namespace MVC_Application1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMovie1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListOfMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListOfMovies");
        }
    }
}
