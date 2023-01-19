namespace CqrsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DomainEvents", "MovieReview_Id", "dbo.MovieReviews");
            DropForeignKey("dbo.DomainEvents", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.DomainEvents", new[] { "MovieReview_Id" });
            DropIndex("dbo.DomainEvents", new[] { "Movie_Id" });
            DropTable("dbo.DomainEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DomainEvents",
                c => new
                    {
                        AggregateRootId = c.Guid(nullable: false),
                        Sequence = c.Int(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        MovieId = c.Guid(),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(),
                        RunningTimeMinutes = c.Int(),
                        MovieId1 = c.Guid(),
                        ReleaseDate1 = c.DateTime(),
                        MovieId2 = c.Guid(),
                        RunningTimeMinutes1 = c.Int(),
                        MovieId3 = c.Guid(),
                        Title1 = c.String(),
                        EntityId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        MovieReview_Id = c.Guid(),
                        Movie_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.AggregateRootId);
            
            CreateIndex("dbo.DomainEvents", "Movie_Id");
            CreateIndex("dbo.DomainEvents", "MovieReview_Id");
            AddForeignKey("dbo.DomainEvents", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.DomainEvents", "MovieReview_Id", "dbo.MovieReviews", "Id");
        }
    }
}
