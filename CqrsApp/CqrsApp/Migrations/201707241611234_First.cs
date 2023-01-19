namespace CqrsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        Reviewer = c.String(),
                        Publication = c.String(),
                        LastEventSequence = c.Int(nullable: false),
                        Movie_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
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
                        EntityId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        MovieReview_Id = c.Guid(),
                        Movie_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.AggregateRootId)
                .ForeignKey("dbo.MovieReviews", t => t.MovieReview_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.MovieReview_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        RunningTimeMinutes = c.Int(nullable: false),
                        LastEventSequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DomainEvents", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieReviews", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.DomainEvents", "MovieReview_Id", "dbo.MovieReviews");
            DropIndex("dbo.DomainEvents", new[] { "Movie_Id" });
            DropIndex("dbo.DomainEvents", new[] { "MovieReview_Id" });
            DropIndex("dbo.MovieReviews", new[] { "Movie_Id" });
            DropTable("dbo.Movies");
            DropTable("dbo.DomainEvents");
            DropTable("dbo.MovieReviews");
        }
    }
}
